using System;

namespace IMT
{
    class IMT
    {
        static void Main(string[] args)
        {
            static void Main(string[] args)
            {
                double height = GetHeight();
                double weight = GetWeight();
                double bmi = CalculateBMI(height, weight);

                string category = GetCategoryAndAdvice(bmi, out string advice);

                ShowResult(bmi, category, advice);
                Console.WriteLine("\nНажмите Enter для выхода...");
                Console.ReadLine();
            }
            static double GetHeight()
            {
                return ReadPositiveDouble("Введите ваш рост (см): ");
            }
            static double GetWeight()
            {
                return ReadPositiveDouble("Введите ваш вес (кг): ");
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
                static double GetHeight()
                {
                    return ReadPositiveDouble("Введите ваш рост (см):");
                }
                static double GetWeight()
                {
                    return ReadPositiveDouble("Введите ваш вес(кг):");
                }
    }