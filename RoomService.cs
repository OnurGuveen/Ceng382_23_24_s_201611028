using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using ReservationSystem;

public class RoomService : IRoomService
{
    public readonly string FilePath = "datas/Data.json";

    [JsonPropertyName("Rooms")]
    public List<Room>? Rooms { get; set; }

    private int nextId = 17;

    //* This function reads datas from Data.json file, saves to Rooms list and then return this list.
    public List<Room> GetRooms()
    {
        try
        {
            //*Read from json
            //* 1 -> json to text
            string jsonString = File.ReadAllText(FilePath);

            //* 2 -> decode text into meaningful classes
            var roomService = JsonSerializer.Deserialize<RoomService>(
                jsonString,
                new JsonSerializerOptions()
                {
                    NumberHandling = JsonNumberHandling.AllowReadingFromString | JsonNumberHandling.WriteAsString
                });

                if (roomService?.Rooms == null){

                    Rooms = new List<Room>();
                }

            Rooms = roomService?.Rooms;

            if (Rooms != null)
            {
                return Rooms;
            }
            else
            {
                return null;
            }
        }
        catch (NotImplementedException notImplementedExceptionMessage)
        {
            Console.WriteLine("Task failed! Exception Details: " + notImplementedExceptionMessage.Message);
            return null;
        }
    }

    //* This function saves datas to Data.json files from Rooms list.
    public void SaveRooms(List<Room> Rooms)
    {
        try
        {
            if (Rooms == null)
            {
                Rooms = new List<Room>();
            }

            //*This part creates next room instance to add Data.json file
            Rooms.Add(new Room()
            {
                Id = nextId.ToString("D3"),
                Name = "A-1" + nextId,
                Capacity = nextId * 2 + 20
            });
            nextId++;

            string json = "{\"Rooms\": " + JsonSerializer.Serialize(Rooms) + "}";
            File.WriteAllText(FilePath, json);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error saving rooms! Exception Details: " + ex.Message);
        }
    }

}