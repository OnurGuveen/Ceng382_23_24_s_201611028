using System;
using System.Text.Json.Serialization;

namespace ReservationSystem
{
    public record Reservation
    {
        [JsonPropertyName("reservationTime")]
        public DateTime Time { get; set; }

        [JsonPropertyName("reservationDate")]
        public DateTime Date { get; set; }

        [JsonPropertyName("reserverName")]
        public string? ReserverName { get; set; }

        [JsonPropertyName("room")]
        public Room? Room { get; set; }

        public DateTime GetTime()
        {
            return this.Time;
        }

        public DateTime GetDate()
        {
            return this.Date;
        }

        public string? GetReserverName()
        {
            return this.ReserverName;
        }

        public Room? GetRoom()
        {
            return this.Room;
        }

        public void SetTime(DateTime time)
        {
            this.Time = time;
        }

        public void SetDate(DateTime date)
        {
            this.Date = date;
        }

        public void SetReserverName(string reserverName)
        {
            this.ReserverName = reserverName;
        }

        public void SetRoom(Room room)
        {
            this.Room = room;
        }

    }
}