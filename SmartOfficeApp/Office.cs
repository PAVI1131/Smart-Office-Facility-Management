using System;
using System.Collections.Generic;

public class Office
{
    private static Office _instance = null;
    private static readonly object _lock = new object();

    public List<Room> Rooms { get; private set; } = new List<Room>();

    private Office() { }

    public static Office Instance
    {
        get
        {
            lock (_lock)
            {
                if (_instance == null)
                    _instance = new Office();
                return _instance;
            }
        }
    }

    public void ConfigureRooms(int count)
    {
        Rooms.Clear();
        for (int i = 1; i <= count; i++)
            Rooms.Add(new Room(i));

        Console.WriteLine($"Office configured with {count} meeting rooms:");
        foreach (var room in Rooms)
            Console.WriteLine($"Room {room.Number}");
    }

    public void SetRoomCapacity(int roomNumber, int capacity)
    {
        var room = Rooms.Find(r => r.Number == roomNumber);
        if (room == null)
        {
            Console.WriteLine($"Room {roomNumber} does not exist.");
            return;
        }
        if (capacity <= 0)
        {
            Console.WriteLine("Invalid capacity. Please enter a valid positive number.");
            return;
        }
        room.MaxCapacity = capacity;
        Console.WriteLine($"Room {room.Number} maximum capacity set to {capacity}.");
    }

    public void AddOccupants(int roomNumber, int count)
    {
        var room = Rooms.Find(r => r.Number == roomNumber);
        if (room == null)
        {
            Console.WriteLine($"Room {roomNumber} does not exist.");
            return;
        }

        room.UpdateOccupancy(count);
    }

    public void ShowRoomStatus(int roomNumber)
    {
        var room = Rooms.Find(r => r.Number == roomNumber);
        if (room == null)
        {
            Console.WriteLine($"Room {roomNumber} does not exist.");
            return;
        }
        room.PrintStatus();
    }
}
