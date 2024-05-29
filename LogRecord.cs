using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ReservationSystem
{
    public record LogRecord
    {

        [JsonPropertyName("timeStamp")]
        public DateTime timeStamp { get; set; }

        [JsonPropertyName("message")]
        public string message { get; set; }

        public LogRecord(DateTime TimeStamp, string Message)
        {

            this.timeStamp = TimeStamp;
            this.message = Message;
        }

        public DateTime GetTimeStamp()
        {
            return this.timeStamp;
        }

        public string GetMessage()
        {
            return this.message;
        }

        public void SetTimeStamp(DateTime TimeStamp)
        {
            this.timeStamp = TimeStamp;
        }

        public void SetMessage(string Message)
        {
            this.message = Message;
        }


    }
}