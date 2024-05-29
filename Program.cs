using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using ReservationSystem;

class Program
{
    static void Main(String[] args)
    {
        Reservation reservation1 = new Reservation();
        reservation1.SetDate(DateTime.Today);
        reservation1.SetTime(DateTime.Now);
        reservation1.SetReserverName("reserver1");
        reservation1.SetRoom(new Room()
        {
            Id = "001",
            Name = "A-101",
            Capacity = 30
        });

        Reservation reservation2 = new Reservation();
        reservation2.SetDate(DateTime.Today);
        reservation2.SetTime(DateTime.Now);
        reservation2.SetReserverName("reserver2");
        reservation2.SetRoom(new Room()
        {
            Id = "002",
            Name = "A-102",
            Capacity = 32
        });

        Reservation reservation3 = new Reservation();
        reservation3.SetDate(DateTime.Today);
        reservation3.SetTime(DateTime.Now);
        reservation3.SetReserverName("reserver3");
        reservation3.SetRoom(new Room()
        {
            Id = "003",
            Name = "A-103",
            Capacity = 34
        });

        Reservation reservation4 = new Reservation();
        reservation4.SetDate(DateTime.Today);
        reservation4.SetTime(DateTime.Now);
        reservation4.SetReserverName("reserver4");
        reservation4.SetRoom(new Room()
        {
            Id = "004",
            Name = "A-104",
            Capacity = 36
        });

        Reservation reservation5 = new Reservation();
        reservation5.SetDate(DateTime.Today);
        reservation5.SetTime(DateTime.Now);
        reservation5.SetReserverName("reserver5");
        reservation5.SetRoom(new Room()
        {
            Id = "005",
            Name = "A-105",
            Capacity = 38
        });

        ReservationHandler reservationHandler = new ReservationHandler();

        reservationHandler.AddReservation(reservation1, reservation1.ReserverName);
        reservationHandler.AddReservation(reservation2, reservation2.ReserverName);
        reservationHandler.AddReservation(reservation3, reservation3.ReserverName);
        reservationHandler.AddReservation(reservation4, reservation4.ReserverName);
        reservationHandler.AddReservation(reservation5, reservation5.ReserverName);

        List<Reservation> reservationList = reservationHandler.GetAllReservations();

        foreach (Reservation reservation in reservationList)
        {

            Console.WriteLine($"Reservation Time : {reservation.Time} Reservation Date : {reservation.Date} Reserver Name : {reservation.ReserverName} Room : {reservation.Room}");
        }

        reservationHandler.DeleteReservation(reservation2);
        reservationHandler.DeleteReservation(reservation3);

        reservationHandler.GetAllReservations().ForEach(reservation => Console.WriteLine(reservation));

        IRoomService roomService = new RoomService();
        List<Room> roomlist = reservationHandler.GetRooms();
        foreach (var room in roomlist)
        {

            Console.WriteLine($"Room ID : {room.Id} | RoomName : {room.Name} | Capacity : {room.Capacity}");
        }

        reservationHandler.SaveRooms(roomlist);
        reservationHandler.SaveRooms(roomlist);
        reservationHandler.SaveRooms(roomlist);

        foreach (var room in roomlist)
        {

            Console.WriteLine($"Room ID : {room.Id} | RoomName : {room.Name} | Capacity : {room.Capacity}");
        }


    
    }
}