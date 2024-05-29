using System.Runtime.InteropServices;
using System.Text.Json;
using System.Text.Json.Serialization;
using ReservationSystem;


public class ReservationRepository : IReservationRepository
{
private readonly string reservationFilePath = "datas/ReservationData.json";
    private readonly string roomFilePath = "datas/Data.json";
    public static List<Reservation> reservations = new List<Reservation>();
    public static List<Room> rooms = new List<Room>();

     public void loadReservations(){
        if (File.Exists(reservationFilePath))
        {
            string json = File.ReadAllText(reservationFilePath);
            var data = JsonSerializer.Deserialize<Dictionary<string, List<Reservation>>>(json);
            reservations=data?["reservations"] ?? new List<Reservation>();

     }
     }
      public void loadRooms(){
        if (File.Exists(roomFilePath))
        {
            string json = File.ReadAllText(roomFilePath);
            var data = JsonSerializer.Deserialize<Dictionary<string, List<Room>>>(json);
            rooms=data?["Rooms"] ?? new List<Room>();

     }
      }
      public void saveReservations(){
        try
        {
            string json = "{\"Reservations\": " + JsonSerializer.Serialize(reservations) + "}";
            File.WriteAllText(reservationFilePath, json);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error saving reservations! Exception Details: " + ex.Message);
        }
      }
      public void saveRooms(){
        try
        {
            string json = "{\"Rooms\": " + JsonSerializer.Serialize(rooms) + "}";
            File.WriteAllText(roomFilePath, json);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error saving rooms! Exception Details: " + ex.Message);
        }
      }
    
    public void AddReservation(Reservation reservation)
    {
       try
        {
            if (reservations == null)
            {
                reservations = new List<Reservation>();
            }

            reservations.Add(reservation);

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
            if (reservations == null)
            {
                
                Console.WriteLine($"{nameof(Reservation)} does not exist.");
            }
            else
            {
                reservations?.Remove(reservation);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error saving rooms! Exception Details: " + ex.Message);
        }
    }

    public List<Reservation> getReservations()
    {
        return reservations;

    }

    public List<Room> getRooms()
    {
        return rooms;
    }

}