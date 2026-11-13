using System;

namespace Train
{
 public class Program
    {
        static void Main(string[] args)
        {
            int startH = GetDepartureHour();
            int startM = GetDepartureMinute();
            double distance = GetDistance();
            double speed = GetSpeed();
            int stops = GetNumberOfStops();
            double stopDuration = GetStopDuration();
            double travelMinutes = CalculateTravelTimeMinutes(distance, speed, stops, stopDuration);
            int travelH = (int)(travelMinutes / 60);
            int travelM = (int)(travelMinutes % 60);
            string arrivalTime = CalculateArrivalTime(startH, startM, travelMinutes);


            ShowResult(travelH, travelM, arrivalTime);


            Console.WriteLine("\nНажмите Enter для выхода...");
            Console.ReadLine();
        }