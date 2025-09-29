using System;

public class LightSensor : ISensor
{
    public void Notify(bool isOccupied)
    {
        if (isOccupied)
            Console.WriteLine("Lights turned on.");
        else
            Console.WriteLine("Lights turned off.");
    }
}
