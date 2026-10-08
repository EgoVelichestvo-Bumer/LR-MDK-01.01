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

    static bool CheckOrder(
        string[] names,
        int[] stock,
        int[] order,
        out int notEnoughIndex)
    {
        for (int i = 0; i < stock.Length; i++)
        {
            if (order[i] > stock[i])
            {
                notEnoughIndex = i;
                return false;
            }
        }

        notEnoughIndex = -1;
        return true;
    }

    static int CalculateCost(int[] prices, int[] order)
    {
        int cost = 0;

        for (int i = 0; i < prices.Length; i++)
        {
            cost += prices[i] * order[i];
        }

        return cost;
    }

    static void UpdateStock(int[] stock, int[] order)
    {
        for (int i = 0; i < stock.Length; i++)
        {
            stock[i] -= order[i];
        }
    }

    static void PrintStock(string[] names, int[] stock)
    {
        Console.WriteLine("Остатки на складе:");

        for (int i = 0; i < names.Length; i++)
        {
            Console.WriteLine($"{names[i]}: {stock[i]}");
        }
    }

    static void Main()
    {
        string[] names =
        {
            "хлеб",
            "молоко",
            "сыр",
            "колбаса",
            "масло"
        };

        int[] prices = { 45, 80, 350, 420, 120 };
        int[] stock = { 30, 25, 12, 8, 15 };

        PrintPriceList(names, prices, stock);

        int[] order = CreateOrder(prices, stock);

        if (CheckOrder(names, stock, order, out int notEnoughIndex))
        {
            int cost = CalculateCost(prices, order);
            UpdateStock(stock, order);

            Console.WriteLine($"Стоимость заказа: {cost} руб.");
        }
        else
        {
            Console.WriteLine(
                $"Товара \"{names[notEnoughIndex]}\" недостаточно на складе.");
        }

        Console.WriteLine();
        PrintStock(names, stock);
    }
}
