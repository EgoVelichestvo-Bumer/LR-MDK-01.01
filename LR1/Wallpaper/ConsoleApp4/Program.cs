using System;

namespace Wallpaper
{
  public  class Program
    {
        static void Main(string[] args)
        {
            double roomLen = GetRoomLength();
            double roomWid = GetRoomWidth();
            double roomHgt = GetRoomHeight();
            double rollWid = GetRollWidth();
            double rollLen = GetRollLength();

            int stripsNeeded = CalculateStripsPerRoom(roomLen, roomWid, rollWid);

            int stripsFromOneRoll = CalculateStripsPerRoll(rollLen, roomHgt);

            int totalRolls = CalculateTotalRolls(stripsNeeded, stripsFromOneRoll);

            ShowResult(stripsNeeded, totalRolls);

            Console.WriteLine("\nНажмите Enter для выхода...");
            Console.ReadLine();
        }
        static double GetRoomLength()
        {
            return ReadPositiveDouble("Введите длину комнаты (м): ");
        }
        static double GetRoomWidth()
        {
            return ReadPositiveDouble("Введите ширину комнаты (м): ");
        }
        static double GetRoomHeight()
        {
            return ReadPositiveDouble("Введите высоту комнаты (м): ");
        }
        static double GetRollWidth()
        {
            return ReadPositiveDouble("Введите ширину рулона (м): ");
        }
        static double GetRollLength()
        {
            return ReadPositiveDouble("Введите длину рулона (м): ");
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
    }