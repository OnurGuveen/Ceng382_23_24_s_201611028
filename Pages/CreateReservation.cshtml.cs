using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using HotelReservationSystem.Data;
using HotelReservationSystem.Models;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace HotelReservationSystem.Pages
{
    public class BookRoomModel : PageModel
    {
        private readonly HotelReservationContext _context;
        private readonly ILogger<BookRoomModel> _logger;

        public BookRoomModel(HotelReservationContext context, ILogger<BookRoomModel> logger)
        {
            _context = context;
            _logger = logger;
        }

        [BindProperty]
        public Reservation Booking { get; set; }

        public IList<Room> AvailableRooms { get; set; }

        public async Task<IActionResult> OnGetAsync(int roomId)
        {
            _logger.LogInformation("OnGetAsync called with roomId: {RoomId}", roomId);

            AvailableRooms = await _context.Rooms.ToListAsync();
            Booking = new Reservation
            {
                RoomId = roomId,
                UserName = HttpContext.Session.GetString("UserEmail") ?? string.Empty
            };

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            _logger.LogInformation("OnPostAsync called with Booking: {@Booking}", Booking);

            if (!ModelState.IsValid)
            {
                _logger.LogWarning("ModelState is invalid.");
                AvailableRooms = await _context.Rooms.ToListAsync();
                return Page();
            }

            Booking.StartDate = DateTime.SpecifyKind(Booking.StartDate, DateTimeKind.Utc);
            Booking.EndDate = DateTime.SpecifyKind(Booking.EndDate, DateTimeKind.Utc);

            _context.Reservations.Add(Booking);
            await _context.SaveChangesAsync();

            _logger.LogInformation("Booking created successfully.");
            return RedirectToPage("/Index");
        }
    }
}
