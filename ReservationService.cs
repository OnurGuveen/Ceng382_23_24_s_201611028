using ReservationSystem;

public class ReservationService : IReservationService
{
    private IReservationRepository reservationRepository =  new ReservationRepository();

    public void reserveRoom(Reservation reservation){
        /*
        foreach (var room in RoomHandler.availableRooms){
            if(room==reservation.room){
                RoomHandler.availableRooms.Remove(room);
            }
        }*/

        RoomHandler.availableRooms.Remove(reservation.room);
    }
    public void deleteReserveRoom(Reservation reservation){
        if(reservation!=null){
            RoomHandler.availableRooms.Add(reservation.room);
        }
        else{
            Console.WriteLine("Error! Room is empty thus ");
        }
    
    }
    
    public void cancelReservation(Reservation reservation)
    {
        reservationRepository.DeleteReservation(reservation);
    }

    public void createReservation(Reservation reservation)
    {
        reservationRepository.AddReservation(reservation);
        
    }
    public static List<Reservation> DisplayReservationByReserver(string name){
       return ReservationRepository.reservations.FindAll(reservation => reservation.reserverName == name);
    }
    public static List<Reservation> DisplayReservationByRoomId(string Id){
        return ReservationRepository.reservations.FindAll(reservation => reservation.room.id == Id);
    }

}