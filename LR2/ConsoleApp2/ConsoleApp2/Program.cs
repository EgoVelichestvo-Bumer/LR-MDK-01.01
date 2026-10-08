using System;

class Program
{
    static void PrintAssortment(string[] names, int[] prices, int[] stock)
    {
        Console.WriteLine("Ассортимент:");

        for (int i = 0; i < names.Length; i++)
        {
            Console.WriteLine(
                $"{i + 1}. {names[i]} — {prices[i]} руб., {stock[i]} уп.");
        }

        Console.WriteLine();
    }

    static int ReadMedicineNumber()
    {
        while (true)
        {
            Console.Write("Введите номер препарата (0 — конец заказа): ");

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
            int number = ReadMedicineNumber();

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
        Console.WriteLine("Остатки упаковок:");

        for (int i = 0; i < names.Length; i++)
        {
            Console.WriteLine($"{names[i]}: {stock[i]}");
        }
    }

    static void Main()
    {
        string[] names =
        {
            "анальгин",
            "аспирин",
            "йод",
            "амоксициллин",
            "витамины"
        };

        int[] prices = { 35, 40, 120, 650, 480 };
        int[] stock = { 30, 25, 20, 12, 15 };

        PrintAssortment(names, prices, stock);

        int[] order = ReadOrder();

        if (CheckOrder(names, stock, order, out int errorIndex))
        {
            int cost = CalculateCost(prices, order);
            UpdateStock(stock, order);

            Console.WriteLine($"Стоимость заказа: {cost} руб.");
        }
        else
        {
            Console.WriteLine(
                $"Препарата \"{names[errorIndex]}\" недостаточно на складе.");
        }

        Console.WriteLine();
        PrintStock(names, stock);
    }
}

