namespace HotelReservationSystem.Models
{
    public class Room
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;  // Odaların adı, varsayılan olarak boş bir string
        public int Capacity { get; set; }  // Oda kapasitesi
        public string View { get; set; } = string.Empty;  // Odaların manzarası, varsayılan olarak boş bir string
        public List<Reservation> Reservations { get; set; } = new List<Reservation>();  // Bu oda için yapılan rezervasyonların listesi, varsayılan olarak boş bir liste

        // Oda bilgilerini daha kullanıcı dostu bir şekilde göstermek için
        public override string ToString()
        {
            return $"Room: {Name}, Capacity: {Capacity}, View: {View}";
        }
    }
}
