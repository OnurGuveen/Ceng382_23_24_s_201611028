using ReservationSystem;

public interface IReservationRepository
{

    public void AddReservation(Reservation reservation);

    public void DeleteReservation(Reservation reservation);

    public List<Reservation> getReservations();
    public List<Room> getRooms();

}