using ReservationSystem;
public class ReservationHandler
{
    private ReservationService reservationService=new ReservationService();
    public void bookRoom(Reservation reservation){
        reservationService.reserveRoom(reservation);
    
    }
    
    public void removeBooking(Reservation reservation){
        reservationService.deleteReserveRoom(reservation);
       
}
}