using ReservationSystem;

public class ReservationService : IReservationService
{
    private Reservation[,] WeeklyReservations = new Reservation[10, 7];

    //*This function adds reservations to WeeklyReservations array.
    public void AddReservation(Reservation reservation, string reserverName)
    {
        try
        {
            bool isReservationAdded = false;

            for (int column = 0; column < 7; column++)
            {
                for (int row = 0; row < 10; row++)
                {
                    if (WeeklyReservations[row, column] == null)
                    {
                        WeeklyReservations[row, column] = reservation;
                        isReservationAdded = true;
                        break;
                    }
                }
                if (isReservationAdded)
                    break;
            }
            if (isReservationAdded)
            {
                Console.WriteLine("Your reservation has been successfully created as: " + reserverName);
            }
            else
            {
                Console.WriteLine("Could not add reservation. Weekly schedule is full.");
            }
        }
        catch (NotImplementedException notImplementedExceptionMessage)
        {
            Console.WriteLine("Task failed! Exception Details: " + notImplementedExceptionMessage.Message);
        }
        catch (NullReferenceException nullReferenceExceptionMessage)
        {
            Console.WriteLine("Task failed! Exception Details: " + nullReferenceExceptionMessage.Message);
        }
    }

    //*This function removes reservations from WeeklyReservations array.
    public void DeleteReservation(Reservation reservation)
    {
        try
        {
            bool isReservationDeleted = false;

            for (int row = 0; row < 10; row++)
            {
                for (int column = 0; column < 7; column++)
                {
                    if (WeeklyReservations[row, column] != null && reservation == WeeklyReservations[row, column])
                    {
                        WeeklyReservations[row, column] = null;
                        isReservationDeleted = true;
                    }
                }
            }
            if (isReservationDeleted)
            {
                Console.WriteLine(reservation.GetReserverName() + "'s reservation deleted successfully.");
            }
            else
            {
                Console.WriteLine("Reservation not found as.");
            }
        }
        catch (NotImplementedException notImplementedExceptionMessage)
        {
            Console.WriteLine("Task failed! Exception Details: " + notImplementedExceptionMessage.Message);
        }
        catch (NullReferenceException nullReferenceExceptionMessage)
        {
            Console.WriteLine("Task failed! Exception Details: " + nullReferenceExceptionMessage.Message);
        }
    }

    //*This function displays WeeklySchedule array to console.
    public void DisplayWeeklySchedule()
    {
        try
        {
        Console.WriteLine("Weekly Reservation Schedule:");
        Console.WriteLine("----------------------------------------------------------------------------------------------------------------------------------------");
        Console.Write("Time\t");

        string[] daysOfWeek = ["Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday"];

        foreach (var day in daysOfWeek)
        {
            Console.Write(day.PadRight(20));
        }
        Console.WriteLine();
        Console.Write("----------------------------------------------------------------------------------------------------------------------------------------");
        Console.WriteLine();

        for (int i = 0; i < 10; i++)
        {
            Console.Write($"{(i + 9).ToString("00")}:00|\t");
            for (int j = 0; j < 7; j++)
            {
                string savedReservation = WeeklyReservations[i, j]?.GetReserverName() ?? " ";
                Console.Write(savedReservation.PadRight(20));
            }
            Console.WriteLine();
        }
        Console.Write("----------------------------------------------------------------------------------------------------------------------------------------");
        Console.WriteLine();
        }
        catch (NotImplementedException notImplementedExceptionMessage)
        {
            Console.WriteLine("Task failed! Exception Details: " + notImplementedExceptionMessage.Message);
        }
    }
}


