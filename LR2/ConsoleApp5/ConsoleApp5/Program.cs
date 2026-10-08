using System;

class Program
{
    static void PrintMaterials(string[] names, int[] prices, int[] stock)
    {
        Console.WriteLine("Расходные материалы:");

        for (int i = 0; i < names.Length; i++)
        {
            Console.WriteLine(
                $"{i + 1}. {names[i]} — {prices[i]} руб., {stock[i]} шт.");
        }

        Console.WriteLine();
    }

    static int ReadMaterialNumber()
    {
        while (true)
        {
            Console.Write(
                "Введите номер материала (0 — конец заказа): ");

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

    static int[] CreateOrder()
    {
        int[] order = new int[5];

        while (true)
        {
            int number = ReadMaterialNumber();

            if (number == 0)
                break;

            int quantity = ReadQuantity();
            order[number - 1] += quantity;
        }

        return order;
    }

    static bool CheckOrder(
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
        Console.WriteLine("Остатки материалов:");

        for (int i = 0; i < names.Length; i++)
        {
            Console.WriteLine($"{names[i]}: {stock[i]}");
        }
    }

    static void Main()
    {
        string[] names =
        {
            "шампунь",
            "пенное средство",
            "воск",
            "микрофибра",
            "щётка"
        };

        int[] prices = { 450, 380, 1200, 250, 600 };
        int[] stock = { 20, 15, 8, 30, 12 };

        PrintMaterials(names, prices, stock);

        int[] order = CreateOrder();

        if (CheckOrder(stock, order, out int errorIndex))
        {
            int total = CalculateCost(prices, order);
            UpdateStock(stock, order);

            Console.WriteLine($"Стоимость заказа: {total} руб.");
        }
        else
        {
            Console.WriteLine(
                $"Материала \"{names[errorIndex]}\" недостаточно на складе.");
        }

        Console.WriteLine();
        PrintRemaining(names, stock);
    }
}
