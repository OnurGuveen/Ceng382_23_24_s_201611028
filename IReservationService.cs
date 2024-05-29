using ReservationSystem;

public interface IReservationService
{

    public void createReservation(Reservation reservation);
    public void cancelReservation(Reservation reservation);

}