using System;

class Program
{
    static void Main(string[] args)
    {
        Office office = Office.Instance;
        Console.WriteLine("Welcome to Smart Office Facility Management!");

        while (true)
        {
            Console.WriteLine("\nChoose an option:");
            Console.WriteLine("1. Configure rooms");
            Console.WriteLine("2. Set room max capacity");
            Console.WriteLine("3. Add occupants");
            Console.WriteLine("4. Book room");
            Console.WriteLine("5. Cancel booking");
            Console.WriteLine("6. Show room status");
            Console.WriteLine("0. Exit");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Enter number of rooms: ");
                    if (int.TryParse(Console.ReadLine(), out int roomCount))
                        office.ConfigureRooms(roomCount);
                    else
                        Console.WriteLine("Invalid input.");
                    break;

                case "2":
                    Console.Write("Enter room number: ");
                    int roomNum1 = int.Parse(Console.ReadLine());
                    Console.Write("Enter max capacity: ");
                    int capacity = int.Parse(Console.ReadLine());
                    office.SetRoomCapacity(roomNum1, capacity);
                    break;

                case "3":
                    Console.Write("Enter room number: ");
                    int roomNum2 = int.Parse(Console.ReadLine());
                    Console.Write("Enter number of occupants: ");
                    int occupants = int.Parse(Console.ReadLine());
                    office.AddOccupants(roomNum2, occupants);
                    break;

                case "4":
                    Console.Write("Enter room number: ");
                    int roomNum3 = int.Parse(Console.ReadLine());
                    Console.Write("Enter booking start time (HH:mm): ");
                    string startTime = Console.ReadLine();
                    Console.Write("Enter duration in minutes: ");
                    int duration = int.Parse(Console.ReadLine());
                    CommandManager.ExecuteCommand(new BookRoomCommand(roomNum3, startTime, duration));
                    break;

                case "5":
                    Console.Write("Enter room number: ");
                    int roomNum4 = int.Parse(Console.ReadLine());
                    CommandManager.ExecuteCommand(new CancelBookingCommand(roomNum4));
                    break;

                case "6":
                    Console.Write("Enter room number: ");
                    int roomNum5 = int.Parse(Console.ReadLine());
                    office.ShowRoomStatus(roomNum5);
                    break;

                case "0":
                    return;

                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
    }
}
