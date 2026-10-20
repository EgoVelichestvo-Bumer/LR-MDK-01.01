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
    static int ReadQuantity()
    {
        while (true)
        {
            Console.Write("Введите количество: ");

            if (int.TryParse(Console.ReadLine(), out int quantity) &&
                quantity >= 0)
            {
                return quantity;
            }

            Console.WriteLine("Ошибка! Количество не может быть меньше нуля.");
        }
    }
    static int[] CreateOrder(int[] prices, int[] stock)
    {
        int[] order = new int[5];

        while (true)
        {
            int number = ReadProductNumber();

            if (number == 0)
                break;

            int quantity = ReadQuantity();
            order[number - 1] += quantity;
        }

        return order;
    }
