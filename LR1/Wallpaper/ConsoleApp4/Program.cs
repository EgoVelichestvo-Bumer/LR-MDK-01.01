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