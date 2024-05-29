using ReservationSystem;

public interface IReservationService{

    public void AddReservation(Reservation reservation, string reserverName);

    public void DeleteReservation(Reservation reservation);

    public void DisplayWeeklySchedule();
}