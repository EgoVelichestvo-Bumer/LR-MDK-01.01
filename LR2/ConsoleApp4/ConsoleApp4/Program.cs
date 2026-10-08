using System;

class Program
{
    static void PrintFlowers(string[] names, int[] prices, int[] stock)
    {
        Console.WriteLine("Ассортимент:");

        for (int i = 0; i < names.Length; i++)
        {
            Console.WriteLine(
                $"{i + 1}. {names[i]} — {prices[i]} руб., {stock[i]} шт.");
        }

        Console.WriteLine();
    }

    static int ReadFlowerNumber()
    {
        while (true)
        {
            Console.Write("Введите номер цветка (0 — конец заказа): ");

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

    static int[] ReadOrder()
    {
        int[] order = new int[5];

        while (true)
        {
            int number = ReadFlowerNumber();

            if (number == 0)
                break;

            int quantity = ReadQuantity();
            order[number - 1] += quantity;
        }

        return order;
    }

    static bool CheckStock(
        int[] stock,
        int[] order,
        out int errorIndex)
    {
        for (int i = 0; i < stock.Length; i++)
        {
            if (order[i] > stock[i])
            {
                errorIndex = i;
                return false;
            }
        }

        errorIndex = -1;
        return true;
    }

    static int CalculateCost(int[] prices, int[] order)
    {
        int total = 0;

        for (int i = 0; i < prices.Length; i++)
        {
            total += prices[i] * order[i];
        }

        return total;
    }

    static void UpdateStock(int[] stock, int[] order)
    {
        for (int i = 0; i < stock.Length; i++)
        {
            stock[i] -= order[i];
        }
    }

    static void PrintRemaining(string[] names, int[] stock)
    {
        Console.WriteLine("Остатки цветов:");

        for (int i = 0; i < names.Length; i++)
        {
            Console.WriteLine($"{names[i]}: {stock[i]}");
        }
    }

    static void Main()
    {
        string[] names =
        {
            "роза",
            "тюльпан",
            "хризантема",
            "орхидея",
            "гипсофила"
        };

        int[] prices = { 180, 120, 350, 1200, 90 };
        int[] stock = { 24, 30, 14, 6, 40 };

        PrintFlowers(names, prices, stock);

        int[] order = ReadOrder();

        if (CheckStock(stock, order, out int errorIndex))
        {
            int total = CalculateCost(prices, order);
            UpdateStock(stock, order);

            Console.WriteLine($"Стоимость заказа: {total} руб.");
        }
        else
        {
            Console.WriteLine(
                $"Цветка \"{names[errorIndex]}\" недостаточно.");
        }

        Console.WriteLine();
        PrintRemaining(names, stock);
    }
}
