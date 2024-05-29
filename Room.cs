using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ReservationSystem
{
    public record Room
    {
        [JsonPropertyName("roomId")]
        public string? id { get; init; }

        [JsonPropertyName("roomName")]
        public string? roomName { get; init; }

        [JsonPropertyName("capacity")]
        public int capacity { get; init; }
    }
}