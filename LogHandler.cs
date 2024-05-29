using ReservationSystem;

public class LogHandler{
    
    private FileLogger fileLogger = new FileLogger();
    public void handleLog(LogRecord record){

        fileLogger.log(record);
        fileLogger.logMessage(record.message);
    }
    public static List<LogRecord> DisplayLogsByName(string name){
        return FileLogger.logList.FindAll(log => log.message == name);
    }
    public static List<LogRecord>DisplayLogs(DateTime start, DateTime end){
        return FileLogger.logList.FindAll(log => log.timeStamp >= start && log.timeStamp <= end);
    }
}