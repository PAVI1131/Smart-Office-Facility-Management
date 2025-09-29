using System;

public class BookRoomCommand : ICommand
{
    private int roomNumber;
    private string startTime;
    private int duration;

    public BookRoomCommand(int roomNumber, string startTime, int duration)
    {
        this.roomNumber = roomNumber;
        this.startTime = startTime;
        this.duration = duration;
    }

    public void Execute()
    {
        var room = Office.Instance.Rooms.Find(r => r.Number == roomNumber);
        if (room == null)
        {
            Console.WriteLine("Invalid room number. Please enter a valid room number.");
            return;
        }

        if (room.IsBooked)
        {
            Console.WriteLine($"Room {roomNumber} is already booked during this time. Cannot book.");
            return;
        }

        room.IsBooked = true;
        room.BookingStart = startTime;
        room.BookingDuration = duration;
        Console.WriteLine($"Room {roomNumber} booked from {startTime} for {duration} minutes.");
    }
}
