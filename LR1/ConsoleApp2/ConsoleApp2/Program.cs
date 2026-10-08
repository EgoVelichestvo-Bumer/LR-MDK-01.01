using System;

namespace DogFood
{
    class Dog
    {
        static void Main(string[] args)
        {
            double weight = ReadPositiveDouble("Введите вес собаки (кг): ");
            int age = ReadIntRange("Введите возраст (1 — щенок, 2 — взрослая): ", 1, 2);
            int activity = ReadIntRange("Введите активность (1 — низкая, 2 — средняя, 3 — высокая): ", 1, 3);

            double dailyNorm = CalculateDailyNorm(weight, age, activity);
            PrintResult(dailyNorm);
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
        }

        static double CalculateDailyNorm(double weight, int ageType, int activityLevel)
        {
            double basePerKg = (ageType == 1) ? 55 : 30;
            double norm = basePerKg * weight;

            switch (activityLevel)
            {
                case 1: norm *= 0.9; break;
                case 2: norm *= 1.0; break;
                case 3: norm *= 1.2; break;
            }
            return norm;
        }

        static void PrintResult(double dailyNorm)
        {
            Console.WriteLine($"Суточная норма корма: {dailyNorm} г");
            Console.WriteLine($"Одна порция (2 кормления в день): {dailyNorm / 2} г");
        }
    }
}