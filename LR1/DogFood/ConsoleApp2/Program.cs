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

        static double GetDogWeight()
        {
            return ReadPositiveDouble("Введите вес собаки (кг): ");
        }

        static int GetDogAgeType()
        {
            Console.WriteLine("Возраст собаки:");
            Console.WriteLine("  1 — щенок");
            Console.WriteLine("  2 — взрослая собака");
            return ReadIntRange("Ваш выбор (1 или 2): ", 1, 2);
        }

        static int GetActivityLevel()
        {
            Console.WriteLine("Уровень активности:");
            Console.WriteLine("  1 — низкая (мало гуляет)");
            Console.WriteLine("  2 — средняя");
            Console.WriteLine("  3 — высокая (много бегает, работает)");
            return ReadIntRange("Ваш выбор (1, 2 или 3): ", 1, 3);
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
                Console.WriteLine($"Ошибка: введите целое число от {min} до {max}.");
            }
            static double CalculateDailyNorm(double weight, int ageType, int activityLevel)
            {
                double basePerKg = (ageType == 1) ? 55 : 30;
                double norm = basePerKg * weight;

                if (activityLevel == 1)
                {
                    norm *= 0.9;
                }
                else if (activityLevel == 3)
                {
                    norm *= 1.2;
                }

                return norm;
            }
        }
    }
    }
}