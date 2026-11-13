using System;

namespace DogFood
{
    class Program
    {

        static void Main(string[] args)
        {
            double weight = GetDogWeight();

            int ageType = GetDogAgeType();

            int activityLevel = GetActivityLevel();

            double dailyNorm = CalculateDailyNorm(weight, ageType, activityLevel);
            ShowResult(dailyNorm);
            Console.WriteLine("\nНажмите Enter для выхода...");
            Console.ReadLine();
        }
    }
    }
}