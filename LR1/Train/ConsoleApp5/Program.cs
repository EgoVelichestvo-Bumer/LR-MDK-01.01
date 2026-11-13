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
        static int GetDepartureHour()
        {
            return ReadIntRange("Введите время отправления (часы, 0-23): ", 0, 23);
        }
        static int GetDepartureMinute()
        {
            return ReadIntRange("Введите время отправления (минуты, 0-59): ", 0, 59);
        }
        static double GetDistance()
        {
            return ReadPositiveDouble("Введите расстояние (км): ");
        }
        static double GetSpeed()
        {
            return ReadPositiveDouble("Введите среднюю скорость (км/ч): ");
        }
        static int GetNumberOfStops()
        {
            return ReadNonNegativeInt("Введите число остановок: ");
        }
        static double GetStopDuration()
        {
            return ReadNonNegativeDouble("Введите время одной остановки (мин): ");
        }