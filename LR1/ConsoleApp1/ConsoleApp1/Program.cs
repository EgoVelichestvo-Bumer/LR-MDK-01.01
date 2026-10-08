using System;

namespace Delivery
{
    class Delivery
    {
        static void Main(string[] args)
        {
            double orderCost = ReadPositiveDouble("Введите стоимость заказа (руб.): ");
            double distance = ReadPositiveDouble("Введите расстояние доставки (км): ");
            int hour = ReadHour("Введите время заказа (час): ");

            double deliveryCost = CalculateDeliveryCost(orderCost, distance, hour);
            PrintResult(deliveryCost, orderCost);
        }

        static double ReadPositiveDouble(string prompt)
        {
            double value;
            while (true)
            {
                Console.Write(prompt);
                if (double.TryParse(Console.ReadLine(), out value) && value >= 0)
                {
                    return value;
                }
                Console.WriteLine("Ошибка: введите корректное неотрицательное число.");
            }
        }

        static int ReadHour(string prompt)
        {
            int value;
            while (true)
            {
                Console.Write(prompt);
                if (int.TryParse(Console.ReadLine(), out value) && value >= 0 && value <= 23)
                {
                    return value;
                }
                Console.WriteLine("Ошибка: введите целое число от 0 до 23.");
            }
        }

        static double CalculateDeliveryCost(double orderCost, double distance, int hour)
        {
            if (orderCost >= 2000)
                return 0;

            double cost = 150;
            if (distance > 3)
            {
                cost += (distance - 3) * 50;
            }

            if ((hour >= 12 && hour < 14) || (hour >= 18 && hour < 20))
            {
                cost *= 1.3;
            }

            return cost;
        }

        static void PrintResult(double deliveryCost, double orderCost)
        {
            Console.WriteLine($"Стоимость доставки: {deliveryCost} руб.");
            Console.WriteLine($"Итого к оплате: {orderCost + deliveryCost} руб.");
        }
    }
}