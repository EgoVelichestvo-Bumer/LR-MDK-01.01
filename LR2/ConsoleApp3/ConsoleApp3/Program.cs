using System;

class Program
{
    static void PrintProducts(string[] names, int[] prices, int[] stock)
    {
        Console.WriteLine("Ассортимент:");

        for (int i = 0; i < names.Length; i++)
        {
            Console.WriteLine(
                $"{i + 1}. {names[i]} — {prices[i]} руб., {stock[i]} шт.");
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

    static int[] FormOrder()
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

    static bool IsOrderPossible(
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

    static int CalculateOrderCost(int[] prices, int[] order)
    {
        int total = 0;

        for (int i = 0; i < prices.Length; i++)
        {
            total += prices[i] * order[i];
        }

        return total;
    }

    static void ApplyOrder(int[] stock, int[] order)
    {
        for (int i = 0; i < stock.Length; i++)
        {
            stock[i] -= order[i];
        }
    }

    static void PrintRemaining(string[] names, int[] stock)
    {
        Console.WriteLine("Остатки:");

        for (int i = 0; i < names.Length; i++)
        {
            Console.WriteLine($"{names[i]}: {stock[i]}");
        }
    }

    static void Main()
    {
        string[] names =
        {
            "ручка",
            "тетрадь",
            "карандаш",
            "акварель",
            "папка"
        };

        int[] prices = { 35, 120, 25, 450, 180 };
        int[] stock = { 40, 25, 30, 12, 15 };

        PrintProducts(names, prices, stock);

        int[] order = FormOrder();

        if (IsOrderPossible(stock, order, out int errorIndex))
        {
            int total = CalculateOrderCost(prices, order);
            ApplyOrder(stock, order);

            Console.WriteLine($"Стоимость заказа: {total} руб.");
        }
        else
        {
            Console.WriteLine(
                $"Товара \"{names[errorIndex]}\" недостаточно на складе.");
        }

        Console.WriteLine();
        PrintRemaining(names, stock);
    }
}
