using System;
using System.Collections.Generic;
using System.Timers; // Use System.Timers explicitly

public class Room
{
    public int Number { get; private set; }
    public int MaxCapacity { get; set; } = 10;
    public int CurrentOccupancy { get; private set; } = 0;
    public bool IsOccupied => CurrentOccupancy >= 2;

    public bool IsBooked { get; set; } = false;
    public string? BookingStart { get; set; } // nullable to avoid warnings
    public int BookingDuration { get; set; }

    private List<ISensor> sensors = new List<ISensor>();
    private readonly System.Timers.Timer occupancyTimer;

    public Room(int number)
    {
        Number = number;
        sensors.Add(new LightSensor());
        sensors.Add(new AcSensor());

        occupancyTimer = new System.Timers.Timer(5 * 60 * 1000); // 5 mins
        occupancyTimer.Elapsed += ReleaseBooking;
        occupancyTimer.AutoReset = false;
    }

    public void UpdateOccupancy(int count)
    {
        CurrentOccupancy = count;

        if (IsOccupied)
        {
            Console.WriteLine($"Room {Number} is now occupied by {count} persons. AC and lights turned on.");
            foreach (var sensor in sensors)
                sensor.Notify(true);

            occupancyTimer.Stop();
        }
        else
        {
            if (count > 0)
            {
                Console.WriteLine($"Room {Number} occupancy insufficient to mark as occupied.");
            }
            else
            {
                Console.WriteLine($"Room {Number} is now unoccupied. AC and lights turned off.");
                foreach (var sensor in sensors)
                    sensor.Notify(false);

                occupancyTimer.Start();
            }
        }
    }

    private void ReleaseBooking(object? sender, ElapsedEventArgs e)
    {
        if (IsBooked && !IsOccupied)
        {
            IsBooked = false;
            Console.WriteLine($"Room {Number} is now unoccupied. Booking released. AC and lights off.");
            foreach (var sensor in sensors)
                sensor.Notify(false);
        }
    }

    public void PrintStatus()
    {
        string status = IsOccupied ? "Occupied" : "Unoccupied";
        string booked = IsBooked ? $"Booked from {BookingStart} for {BookingDuration} mins" : "Not booked";
        Console.WriteLine($"Room {Number}: {status}, {booked}");
    }
}
