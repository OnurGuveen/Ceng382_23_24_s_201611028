using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using HotelReservationSystem.Data;
using HotelReservationSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace HotelReservationSystem.Pages
{
    public class HomePageModel : PageModel
    {
        private readonly HotelReservationContext _dbContext;
        private readonly ILogger<HomePageModel> _logger;

        public HomePageModel(HotelReservationContext dbContext, ILogger<HomePageModel> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        [BindProperty]
        public Room CurrentRoom { get; set; } = new Room();

        public IList<Room> AvailableRooms { get; set; } = new List<Room>();

        [BindProperty]
        public Reservation CurrentReservation { get; set; } = new Reservation();

        public IList<Reservation> ExistingReservations { get; set; } = new List<Reservation>();

        public string RoomNameFilter { get; set; }
        public DateTime? StartDateFilter { get; set; }
        public DateTime? EndDateFilter { get; set; }
        public int? CapacityFilter { get; set; }

        public async Task OnLoadAsync(string roomNameFilter, DateTime? startDateFilter, DateTime? endDateFilter, int? capacityFilter)
        {
            RoomNameFilter = roomNameFilter;
            StartDateFilter = startDateFilter;
            EndDateFilter = endDateFilter;
            CapacityFilter = capacityFilter;

            var roomQuery = _dbContext.Rooms.Include(r => r.Reservations).AsQueryable();
            var reservationQuery = _dbContext.Reservations.Include(r => r.Room).AsQueryable();

            if (!string.IsNullOrEmpty(RoomNameFilter))
            {
                roomQuery = roomQuery.Where(r => r.Name.Contains(RoomNameFilter));
            }
            if (StartDateFilter.HasValue)
            {
                reservationQuery = reservationQuery.Where(r => r.StartDate >= StartDateFilter.Value);
            }
            if (EndDateFilter.HasValue)
            {
                reservationQuery = reservationQuery.Where(r => r.EndDate <= EndDateFilter.Value);
            }
            if (CapacityFilter.HasValue)
            {
                roomQuery = roomQuery.Where(r => r.Capacity >= CapacityFilter.Value);
            }

            AvailableRooms = await roomQuery.ToListAsync();
            ExistingReservations = await reservationQuery.ToListAsync();
        }

        public async Task<IActionResult> OnPostCreateRoomAsync()
        {
            if (!ModelState.IsValid)
            {
                _logger.LogWarning("Geçersiz model durumu: {@ModelState}", ModelState);
                AvailableRooms = await _dbContext.Rooms.Include(r => r.Reservations).ToListAsync();
                ExistingReservations = await _dbContext.Reservations.Include(r => r.Room).ToListAsync();
                return Page();
            }

            _logger.LogInformation("Oda oluşturuluyor: {@Room}", CurrentRoom);
            _dbContext.Rooms.Add(CurrentRoom);

            try
            {
                await _dbContext.SaveChangesAsync();
                _logger.LogInformation("Oda oluşturuldu: {@Room}", CurrentRoom);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Oda oluşturulurken hata oluştu.");
            }

            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostUpdateReservationAsync()
        {
            if (!ModelState.IsValid)
            {
                _logger.LogWarning("Geçersiz model durumu: {@ModelState}", ModelState);
                AvailableRooms = await _dbContext.Rooms.Include(r => r.Reservations).ToListAsync();
                ExistingReservations = await _dbContext.Reservations.Include(r => r.Room).ToListAsync();
                return Page();
            }

            var reservationToUpdate = await _dbContext.Reservations.FindAsync(CurrentReservation.Id);
            if (reservationToUpdate == null)
            {
                _logger.LogWarning("Rezervasyon bulunamadı: {ReservationId}", CurrentReservation.Id);
                return NotFound();
            }

            reservationToUpdate.StartDate = DateTime.SpecifyKind(CurrentReservation.StartDate, DateTimeKind.Utc);
            reservationToUpdate.EndDate = DateTime.SpecifyKind(CurrentReservation.EndDate, DateTimeKind.Utc);

            try
            {
                await _dbContext.SaveChangesAsync();
                _logger.LogInformation("Rezervasyon güncellendi: {ReservationId}", CurrentReservation.Id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Rezervasyon güncellenirken hata oluştu.");
            }

            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostRemoveReservationAsync(int id)
        {
            var reservation = await _dbContext.Reservations.FindAsync(id);
            if (reservation == null)
            {
                _logger.LogWarning("Rezervasyon bulunamadı: {ReservationId}", id);
                return NotFound();
            }

            _dbContext.Reservations.Remove(reservation);

            try
            {
                await _dbContext.SaveChangesAsync();
                _logger.LogInformation("Rezervasyon silindi: {ReservationId}", id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Rezervasyon silinirken hata oluştu.");
            }

            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostRemoveRoomAsync(int roomId)
        {
            var room = await _dbContext.Rooms.FindAsync(roomId);
            if (room == null)
            {
                _logger.LogWarning("Oda bulunamadı: {RoomId}", roomId);
                return NotFound();
            }

            var reservations = _dbContext.Reservations.Where(r => r.RoomId == roomId);
            _dbContext.Reservations.RemoveRange(reservations);
            _dbContext.Rooms.Remove(room);

            try
            {
                await _dbContext.SaveChangesAsync();
                _logger.LogInformation("Oda silindi: {RoomId}", roomId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Oda silinirken hata oluştu.");
            }

            return RedirectToPage();
        }

        public bool CheckRoomAvailability(int roomId, DateTime startDate, DateTime endDate)
        {
            var overlappingReservations = _dbContext.Reservations
                .Where(r => r.RoomId == roomId &&
                            ((r.StartDate <= startDate && r.EndDate >= startDate) ||
                             (r.StartDate <= endDate && r.EndDate >= endDate) ||
                             (r.StartDate >= startDate && r.EndDate <= endDate)))
                .ToList();

            return !overlappingReservations.Any();
        }
    }
}
