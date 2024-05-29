using System;

namespace ReservationSystem
{
    public record LogRecord
    {
        private DateTime TimeStamp;
        private string ReserverName;
        private string RoomName;

        public LogRecord(DateTime timeStamp, string reserverName, string roomName){

            TimeStamp = timeStamp;
            ReserverName = reserverName;
            RoomName = roomName;
        }

        public DateTime GetTimeStamp(){
            return this.TimeStamp;
        }

        public string GetReserverName(){
            return this.ReserverName;
        }

        public string GetRoomName(){
            return this.RoomName;
        }

        public void SetTimeStamp(DateTime timeStamp){
            this.TimeStamp = timeStamp;
        }

        public void SetReserverName(string reserverName){
            this.ReserverName = reserverName;
        }

        public void SetRoomName(string roomName){
            this.RoomName = roomName;
        }
    }
}