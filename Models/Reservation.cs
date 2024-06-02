namespace HotelReservationSystem.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public int RoomId { get; set; }
        public string UserName { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public Room? Room { get; set; } // Varsayılan değer kaldırıldı, nullable olarak işaretlendi
    }
}
