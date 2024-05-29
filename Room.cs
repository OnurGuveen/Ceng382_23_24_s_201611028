using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ReservationSystem
{
    public record Room
    {
        [JsonPropertyName("roomId")]
        public string? Id { get; init; }

        [JsonPropertyName("roomName")]
        public string? Name { get; init; }

        [JsonPropertyName("capacity")]
        public int Capacity { get; init; }
    }
}