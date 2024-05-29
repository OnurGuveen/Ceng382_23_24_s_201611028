using System;
using System.Text.Json.Serialization;

namespace ReservationSystem
{
    public record Reservation
    {
        [JsonPropertyName("reservationTime")]
        public DateTime time { get; set; }

        [JsonPropertyName("reservationDate")]
        public DateTime date { get; set; }

        [JsonPropertyName("reserverName")]
        public string? reserverName { get; set; }

        [JsonPropertyName("room")]
        public Room? room { get; set; }

        public DateTime GetTime()
        {
            return this.time;
        }

        public DateTime GetDate()
        {
            return this.date;
        }

        public string? GetReserverName()
        {
            return this.reserverName;
        }

        public Room? GetRoom()
        {
            return this.room;
        }

        public void SetTime(DateTime time)
        {
            this.time = time;
        }

        public void SetDate(DateTime date)
        {
            this.date = date;
        }

        public void SetReserverName(string reserverName)
        {
            this.reserverName = reserverName;
        }

        public void SetRoom(Room room)
        {
            this.room = room;
        }

    }
}