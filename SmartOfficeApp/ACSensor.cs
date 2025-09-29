using System;

public class AcSensor : ISensor
{
    public void Notify(bool isOccupied)
    {
        if (isOccupied)
            Console.WriteLine("AC turned on.");
        else
            Console.WriteLine("AC turned off.");
    }
}
