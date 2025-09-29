using System;

public class CancelBookingCommand : ICommand
{
    private int roomNumber;

    public CancelBookingCommand(int roomNumber)
    {
        this.roomNumber = roomNumber;
    }

    public void Execute()
    {
        var room = Office.Instance.Rooms.Find(r => r.Number == roomNumber);
        if (room == null)
        {
            Console.WriteLine("Invalid room number. Please enter a valid room number.");
            return;
        }

        if (!room.IsBooked)
        {
            Console.WriteLine($"Room {roomNumber} is not booked. Cannot cancel booking.");
            return;
        }

        room.IsBooked = false;
        Console.WriteLine($"Booking for Room {roomNumber} cancelled successfully.");
    }
}
