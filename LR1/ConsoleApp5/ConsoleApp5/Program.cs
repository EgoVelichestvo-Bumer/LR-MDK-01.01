using System;

namespace Task5_Train
{
    class Program
    {
        static void Main(string[] args)
        {
            int startH = ReadIntRange("Введите время отправления (часы): ", 0, 23);
            int startM = ReadIntRange("Введите время отправления (минуты): ", 0, 59);

            double distance = ReadPositiveDouble("Введите расстояние (км): ");
            double speed = ReadPositiveDouble("Введите среднюю скорость (км/ч): ");

            int stops = ReadNonNegativeInt("Введите число остановок: ");
            double stopDur = ReadNonNegativeDouble("Введите время остановки (мин): ");

            double travelMinutes = CalculateTravelTimeMinutes(distance, speed, stops, stopDur);

            int travelH = (int)(travelMinutes / 60);
            int travelM = (int)(travelMinutes % 60);
            Console.WriteLine($"Время в пути: {travelH} ч {travelM} мин");

            string arrivalTime = CalculateArrivalTime(startH, startM, travelMinutes);
            Console.WriteLine($"Время прибытия: {arrivalTime}");
        }

        static int ReadIntRange(string prompt, int min, int max)
        {
            int value;
            while (true)
            {
                Console.Write(prompt);
                if (int.TryParse(Console.ReadLine(), out value) && value >= min && value <= max)
                    return value;
                Console.WriteLine($"Ошибка: введите число от {min} до {max}.");
            }
        }

        static double ReadPositiveDouble(string prompt)
        {
            double value;
            while (true)
            {
                Console.Write(prompt);
                if (double.TryParse(Console.ReadLine(), out value) && value > 0)
                    return value;
                Console.WriteLine("Ошибка: введите число больше нуля.");
            }
        }

        static int ReadNonNegativeInt(string prompt)
        {
            int value;
            while (true)
            {
                Console.Write(prompt);
                if (int.TryParse(Console.ReadLine(), out value) && value >= 0)
                    return value;
                Console.WriteLine("Ошибка: введите неотрицательное целое число.");
            }
        }

        static double ReadNonNegativeDouble(string prompt)
        {
            double value;
            while (true)
            {
                Console.Write(prompt);
                if (double.TryParse(Console.ReadLine(), out value) && value >= 0)
                    return value;
                Console.WriteLine("Ошибка: введите неотрицательное число.");
            }
        }

        static double CalculateTravelTimeMinutes(double dist, double speed, int stops, double stopDur)
        {
            double moveMinutes = (dist / speed) * 60;
            double stopMinutes = stops * stopDur;
            return moveMinutes + stopMinutes;
        }

        static string CalculateArrivalTime(int h, int m, double travelMinutesTotal)
        {
            int startTotalMinutes = h * 60 + m;
            int arrivalTotalMinutes = (int)(startTotalMinutes + travelMinutesTotal);

            arrivalTotalMinutes = arrivalTotalMinutes % (24 * 60);

            int arrH = arrivalTotalMinutes / 60;
            int arrM = arrivalTotalMinutes % 60;

            return $"{arrH:D2}:{arrM:D2}";
        }
    }
}