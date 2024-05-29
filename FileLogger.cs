using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Text.Json.Serialization;
using ReservationSystem;

public class FileLogger : ILogger
{
    public static List<LogRecord> logList = new List<LogRecord>();
    private readonly string FilePath = "datas/LogData.json";

    public void log(LogRecord record)
    {
        try
        {
            if (logList == null)
            {
                logList = new List<LogRecord>();
            }

            logList.Add(record);

            string json = "{\"Loggers\": " + JsonSerializer.Serialize(logList) + "}";
            File.WriteAllText(FilePath, json);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error saving Log ! " + ex.Message);
        }

    }
    public void logMessage(string message)
    {
        Console.WriteLine(message);
    }
}