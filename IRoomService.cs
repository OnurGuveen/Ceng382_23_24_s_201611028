using ReservationSystem;

public interface IRoomService{

    public List<Room> GetRooms();
    public void SaveRooms(List<Room> rooms);
}