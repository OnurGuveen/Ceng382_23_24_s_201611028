using ReservationSystem;
public class RoomHandler{
public static List<Room>availableRooms = new List<Room>();

 public readonly string FilePath = "datas/Data.json";
    private int nextId = 17;
    public void manageRoom(Room room){
        try
        {
            if (ReservationRepository.rooms == null)
            {
                ReservationRepository.rooms= new List<Room>();
            }

           ReservationRepository.rooms.Add(room);
            nextId++;
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error saving rooms! Exception Details: " + ex.Message);
        }
    }
    public List<Room>listAvailableRooms(){
        
        return availableRooms;
    }
}