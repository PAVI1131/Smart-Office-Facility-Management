 Smart Office Facility Management

A console-based application to manage a smart office facility.
The system handles conference room bookings, occupancy detection, and automated control of air conditioning and lighting based on room occupancy.

Features

* Configure office facility with a specified number of meeting rooms.
* Book and cancel conference room bookings.
* Occupancy detection using sensors (minimum 2 people required to mark a room as “occupied”).
* Automatically release bookings if the room is unoccupied for 5 minutes.
* Automatically control AC and lights based on occupancy.
Design Patterns Used

* **Singleton Pattern**
  `Office` class ensures a single instance of the office configuration throughout the application.

* **Observer Pattern**
  Sensors (`LightSensor`, `AcSensor`) observe room occupancy changes and react automatically.

* **Command Pattern**
  Operations like booking and cancellation are encapsulated as commands (`BookRoomCommand`, `CancelBookingCommand`).

 Project Structure
SmartOfficeApp/
│
├─ Program.cs               # Main entry point with menu-driven switch case
├─ Office.cs                # Singleton office configuration
├─ Room.cs                  # Room entity with occupancy + booking logic
├─ ISensor.cs               # Observer interface
├─ LightSensor.cs           # Concrete observer (lights control)
├─ AcSensor.cs              # Concrete observer (AC control)
├─ ICommand.cs              # Command interface
├─ BookRoomCommand.cs       # Concrete command for booking
├─ CancelBookingCommand.cs  # Concrete command for cancellation
├─ CommandManager.cs        # Command invoker
└─ README.md


 Build & Run

 Build the project:

   dotnet build

 Run the app:
   dotnet run
 Usage

When you run the application, you will see a menu:
Welcome to Smart Office Facility Management!

Choose an option:
1. Configure rooms
2. Set room max capacity
3. Add occupants
4. Book room
5. Cancel booking
6. Show room status
0. Exit

> 1
Enter number of rooms: 3
Office configured with 3 meeting rooms:
Room 1
Room 2
Room 3

> 2
Enter room number: 1
Enter max capacity: 10
Room 1 maximum capacity set to 10.

> 3
Enter room number: 1
Enter number of occupants: 2
Room 1 is now occupied by 2 persons. AC and lights turned on.
Lights turned on.
AC turned on.

> 4
Enter room number: 1
Enter booking start time (HH:mm): 09:00
Enter duration in minutes: 60
Room 1 booked from 09:00 for 60 minutes.

> 6
Enter room number: 1
Room 1: Occupied, Booked from 09:00 for 60 mins

