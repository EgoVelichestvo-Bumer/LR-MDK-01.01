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