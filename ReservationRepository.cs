using System.Text.Json;
using System.Text.Json.Serialization;
using ReservationSystem;

public class ReservationRepository : IReservationRepository
{

    private readonly string FilePath = "datas/ReservationData.json";

    [JsonPropertyName("Reservations")]
    public List<Reservation>? Reservations { get; set; }


    public void AddReservation(Reservation reservation)
    {
        try
        {
            if (Reservations == null)
            {
                Reservations = new List<Reservation>();
            }

            Reservations.Add(reservation);


            string json = "{\"Reservations\": " + JsonSerializer.Serialize(Reservations) + "}";
            File.WriteAllText(FilePath, json);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error saving rooms! Exception Details: " + ex.Message);
        }
    }

    public void DeleteReservation(Reservation reservation)
    {
        try
        {
            if (Reservations == null)
            {
                Console.WriteLine($"{nameof(Reservation)} does not exist.");
            }
            else
            {
                Reservations?.Remove(reservation);

                string json = "{\"Reservations\": " + JsonSerializer.Serialize(Reservations) + "}";
                File.WriteAllText(FilePath, json);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error saving rooms! Exception Details: " + ex.Message);
        }
    }

    public List<Reservation> GetAllReservations()
    {
        try
        {
            string jsonString = File.ReadAllText(FilePath);

            var reservationRepository = JsonSerializer.Deserialize<ReservationRepository>(
                jsonString,
                new JsonSerializerOptions()
                {
                    NumberHandling = JsonNumberHandling.AllowReadingFromString | JsonNumberHandling.WriteAsString
                });

            if (Reservations == null)
            {
                Reservations = new List<Reservation>();
            }

            Reservations = reservationRepository?.Reservations;

            if (Reservations != null)
            {

                return Reservations;
            }
            else{
                return null;
            }
        }
        catch (NotImplementedException notImplementedExceptionMessage)
        {
            Console.WriteLine("Task failed! Exception Details: " + notImplementedExceptionMessage.Message);
            return null;
        }
    }
}
