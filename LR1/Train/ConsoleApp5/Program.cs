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
        static double CalculateTravelTimeMinutes(double dist, double speed, int stops, double stopDur)
        {
            double moveMinutes = (dist / speed) * 60;
            double stopMinutes = stops * stopDur;

            return moveMinutes + stopMinutes;
        }
        static int ReadIntRange(string prompt, int min, int max)
        {
            int value;
            while (true) 
            {
                Console.Write(prompt);
                if (int.TryParse(Console.ReadLine(), out value) && value >= min && value <= max)
                {
                    return value; 
                }
                Console.WriteLine($"Ошибка: введите число от {min} до {max}.");
            }
            static string CalculateArrivalTime(int h, int m, double travelMinutesTotal)
            {
                int startTotalMinutes = h * 60 + m;
                int arrivalTotalMinutes = (int)(startTotalMinutes + travelMinutesTotal);
                arrivalTotalMinutes = arrivalTotalMinutes % (24 * 60);
                int arrH = arrivalTotalMinutes / 60;
                int arrM = arrivalTotalMinutes % 60;

                return
            }
        }