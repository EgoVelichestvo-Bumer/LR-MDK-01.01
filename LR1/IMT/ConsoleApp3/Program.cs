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
                static double CalculateBMI(double heightCm, double weightKg)
                {
                    double heightM = heightCm / 100.0;
                    return weightKg / (heightM * heightM);
                    static string GetCategoryAndAdvice(double bmi, out string advice)
                    {
                        if (bmi < 18.5)
                        {
                            advice = "Увеличьте калорийность рациона.";
                            return "Недостаточный вес";
                        }
                        else if (bmi >= 18.5 && bmi <= 25)
                        {
                            advice = "Поддерживайте текущий образ жизни.";
                            return "Норма";
                        }
                        else if (bmi > 25 && bmi <= 30)
                        {
                            advice = "Увеличьте физическую активность.";
                            return "Избыточный вес";
                        }
                        else
                        {
                            advice = "Обратитесь к врачу.";
                            return "Ожирение";
                        }
                    }

                }
            }