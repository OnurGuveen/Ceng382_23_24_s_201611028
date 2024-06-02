namespace HotelReservationSystem.Models
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; } = string.Empty;  // Kullanıcı adı, varsayılan olarak boş bir string
        public string Password { get; set; } = string.Empty;  // Kullanıcı şifresi, varsayılan olarak boş bir string
        public string Email { get; set; } = string.Empty;  // Kullanıcı e-posta adresi, varsayılan olarak boş bir string
        public string Gender { get; set; } = string.Empty;  // Kullanıcı cinsiyeti, varsayılan olarak boş bir string
        public int Age { get; set; }  // Kullanıcı yaşı

        // Kullanıcı bilgilerini daha kullanıcı dostu bir şekilde göstermek için
        public override string ToString()
        {
            return $"User: {UserName}, Email: {Email}, Gender: {Gender}, Age: {Age}";
        }
    }
}
