using System;

class Program
{

    static void PrintPriceList(string[] names, int[] prices, int[] stock)
    {
        Console.WriteLine("Прайс-лист:");

        for (int i = 0; i < names.Length; i++)
        {
            Console.WriteLine($"{i + 1}. {names[i]} — {prices[i]} руб., {stock[i]} шт.");
        }

        Console.WriteLine();
    }
    static int ReadProductNumber()
    {
        while (true)
        {
            Console.Write("Введите номер товара (0 — конец заказа): ");

            if (int.TryParse(Console.ReadLine(), out int number) &&
                number >= 0 && number <= 5)
            {
                return number;
            }

            Console.WriteLine("Ошибка! Введите число от 0 до 5.");
        }
    }