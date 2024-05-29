using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using ReservationSystem;

class Program
{
    static void Main(String[] args)
    {
        LogHandler logHandler = new LogHandler();
        RoomHandler roomHandler = new RoomHandler();
        ReservationService reservationService = new ReservationService();
        ReservationRepository reservationRepository = new ReservationRepository();

        reservationRepository.loadRooms();
        RoomHandler.availableRooms = reservationRepository.getRooms();

        Reservation reservation1 = new Reservation()
        {
            date = DateTime.Today,
            time = DateTime.Now,
            reserverName = "reserver1",
            room = RoomHandler.availableRooms[0]
        };
        reservationService.createReservation(reservation1);
        reservationService.reserveRoom(reservation1);
        logHandler.handleLog(new LogRecord(DateTime.Today, "reserver1"));

        Reservation reservation2 = new Reservation()
        {
            date = DateTime.Today,
            time = DateTime.Now,
            reserverName = "reserver2",
            room = RoomHandler.availableRooms[1]
        };
        reservationService.createReservation(reservation2);
        reservationService.reserveRoom(reservation2);
        logHandler.handleLog(new LogRecord(DateTime.Today, "reserver2"));

        Reservation reservation3 = new Reservation()
        {
            date = DateTime.Today,
            time = DateTime.Now,
            reserverName = "reserver3",
            room = RoomHandler.availableRooms[2]
        };
        reservationService.createReservation(reservation3);
        reservationService.reserveRoom(reservation3);
        logHandler.handleLog(new LogRecord(DateTime.Today, "reserver3"));

        Reservation reservation4 = new Reservation()
        {
            date = DateTime.Today,
            time = DateTime.Now,
            reserverName = "reserver4",
            room = RoomHandler.availableRooms[3]
        };
        reservationService.createReservation(reservation4);
        reservationService.reserveRoom(reservation4);
        logHandler.handleLog(new LogRecord(DateTime.Today, "reserver4"));

        Reservation reservation5 = new Reservation()
        {
            date = DateTime.Today,
            time = DateTime.Now,
            reserverName = "reserver5",
            room = RoomHandler.availableRooms[4]
        };
        reservationService.createReservation(reservation5);
        reservationService.reserveRoom(reservation5);
        logHandler.handleLog(new LogRecord(DateTime.Today, "reserver5"));

        Reservation reservation6 = new Reservation()
        {
            date = DateTime.Today,
            time = DateTime.Now,
            reserverName = "reserver6",
            room = RoomHandler.availableRooms[5]
        };
        reservationService.createReservation(reservation6);
        reservationService.reserveRoom(reservation6);
        logHandler.handleLog(new LogRecord(DateTime.Today, "reserver6"));

        reservationService.cancelReservation(reservation1);
        reservationService.cancelReservation(reservation2);

        reservationRepository.saveReservations();
        Console.WriteLine("------------------------------------------------");
        Console.WriteLine("Filtered Logs for messages (First filtered to 'reserver3' / second filtered to 'reserver4')");

       List<LogRecord>logs=LogHandler.DisplayLogsByName(reservation3.reserverName);
       foreach (var logRecord in logs){
        Console.WriteLine(logRecord.message);
       }
        logs=LogHandler.DisplayLogsByName(reservation4.reserverName);
       foreach (var logRecord in logs){
        Console.WriteLine(logRecord.message);
       }

        Console.WriteLine("------------------------------------------------");
        Console.WriteLine("Filtered Logs for times (Filtered to reservations done between Yesterday-Tomorrow) ");
        DateTime startDate = DateTime.Today.AddDays(-1);
        DateTime endDate = DateTime.Today.AddDays(+1);
       List<LogRecord>logss=LogHandler.DisplayLogs(startDate,endDate);
       foreach (var logRecord in logss){
        Console.WriteLine(logRecord.message);
       }

        Console.WriteLine("------------------------------------------------");
        Console.WriteLine("Filtered reservations by name(First filtered to 'reserver6' / Second filtered to 'reserver5' )");

       List<Reservation> reservations = ReservationService.DisplayReservationByReserver("reserver6");
        foreach (Reservation res in reservations)
        {
            Console.WriteLine($"Rezervasyon ID: {res.room.id}, Rezervasyon Tarihi: {res.date.ToShortDateString()}, Oda Adı: {res.room.roomName}");
        }
        reservations=ReservationService.DisplayReservationByReserver("reserver5");
        foreach (Reservation res in reservations)
        {
            Console.WriteLine($"Rezervasyon ID: {res.room.id}, Rezervasyon Tarihi: {res.date.ToShortDateString()}, Oda Adı: {res.room.roomName}");
        }
        Console.WriteLine("------------------------------------------------");
        Console.WriteLine("Filtered reservations by Id(First filtered to reservation3's id / Second filtered to reservation4's id)");

       List<Reservation> reservationss = ReservationService.DisplayReservationByRoomId(reservation3.room.id);
        foreach (Reservation res in reservationss)
        {
            Console.WriteLine($"Rezervasyon ID: {res.room.id}, Rezervasyon Tarihi: {res.date.ToShortDateString()}, Oda Adı: {res.room.roomName}");
        }
        reservations=ReservationService.DisplayReservationByRoomId(reservation4.room.id);
        foreach (Reservation res in reservationss)
        {
            Console.WriteLine($"Rezervasyon ID: {res.room.id}, Rezervasyon Tarihi: {res.date.ToShortDateString()}, Oda Adı: {res.room.roomName}");
        }


    }
}