using System;

namespace Task4_Wallpaper
{
    class Program
    {
        static void Main(string[] args)
        {
            double roomLen = ReadPositiveDouble("Введите длину комнаты (м): ");
            double roomWid = ReadPositiveDouble("Введите ширину комнаты (м): ");
            double roomHgt = ReadPositiveDouble("Введите высоту комнаты (м): ");

            double rollWid = ReadPositiveDouble("Введите ширину рулона (м): ");
            double rollLen = ReadPositiveDouble("Введите длину рулона (м): ");

            int stripsNeeded = CalculateStripsPerRoom(roomLen, roomWid, rollWid);
            int stripsFromOneRoll = CalculateStripsPerRoll(rollLen, roomHgt);

            if (stripsFromOneRoll == 0) stripsFromOneRoll = 1;

            int totalRolls = CalculateTotalRolls(stripsNeeded, stripsFromOneRoll);

            Console.WriteLine($"Количество полос: {stripsNeeded}");
            Console.WriteLine($"Количество рулонов: {totalRolls}");
        }

        static double ReadPositiveDouble(string prompt)
        {
            double value;
            while (true)
            {
                Console.Write(prompt);
                if (double.TryParse(Console.ReadLine(), out value) && value > 0)
                {
                    return value;
                }
                Console.WriteLine("Ошибка: введите число больше нуля.");
            }
        }

        static int CalculateStripsPerRoom(double length, double width, double rollWidth)
        {
            double perimeter = (length + width) * 2;
            return (int)Math.Ceiling(perimeter / rollWidth);
        }

        static int CalculateStripsPerRoll(double rollLength, double roomHeight)
        {
            double stripHeight = roomHeight + 0.1;
            if (stripHeight <= 0) return 0;
            return (int)(rollLength / stripHeight);
        }

        static int CalculateTotalRolls(int totalStrips, int stripsPerRoll)
        {
            if (stripsPerRoll <= 0) return 0;
            return (int)Math.Ceiling((double)totalStrips / stripsPerRoll);
        }
    }
}