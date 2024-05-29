using ReservationSystem;
public class ReservationHandler
{

    IReservationService _reservationService;
    IReservationRepository _reservationRepository;
    IRoomService _roomService;
    ILogger _logger;

    public ReservationHandler()
    {
        _reservationService = new ReservationService();
        _reservationRepository = new ReservationRepository();
        _roomService = new RoomService();
        _logger = new FileLogger();
    }

    public void AddReservation(Reservation reservation, string reserverName)
    {

        _reservationService.AddReservation(reservation, reserverName);
        _reservationRepository.AddReservation(reservation);
        

        _reservationService.DisplayWeeklySchedule();
    }

    public void DeleteReservation(Reservation reservation)
    {

        _reservationService.DeleteReservation(reservation);
        _reservationRepository.DeleteReservation(reservation);

        _reservationService.DisplayWeeklySchedule();
    }

    public List<Reservation> GetAllReservations(){

        List<Reservation> reservations= new List<Reservation>();
        reservations = _reservationRepository.GetAllReservations();

        if(reservations != null){

            return reservations;
        }
        else{
            return null;
        }
    }

     public List<Room> GetRooms(){

       return _roomService.GetRooms();
     }

     public void SaveRooms(List<Room> rooms){

        _roomService.SaveRooms(rooms);
     }
}