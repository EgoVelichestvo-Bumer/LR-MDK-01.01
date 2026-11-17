using System;

namespace Delivery
{
   public class Program
    {
        static void Main(string[] args)
        {         
            double orderCost = GetOrderCost();

            double distance = GetDistance();

            int hour = GetDeliveryHour();

            double deliveryCost = CalculateDeliveryCost(orderCost, distance, hour);

            ShowResult(deliveryCost, orderCost);

            Console.WriteLine("Нажмите Enter для выхода...");
            Console.ReadLine();
        }
        static double GetOrderCost()
        {
            return ReadPositiveDouble("Введите стоимость заказа (руб.): ");
        }
        static double GetDistance()
        {
            return ReadPositiveDouble("Введите расстояние доставки (км): ");
        }
        static int GetDeliveryHour()
        {
            return ReadHour("Введите время заказа (час от 0 до 23): ");
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
        /// HERE
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
            {
                return 0;
            }

            double cost = 150;

            if (distance>3)
            {
                cost += (distance - 3) * 50;
            }

            if (hour >= 12 && hour < 14) ;
            {
                distance *= 1.3;
            }
            if (hour >= 18 && hour < 20) ;
            {
                cost *= 1.3;
            }
            return cost;
        }
        
        static void ShowResult(double deliveryCost, double orderCost)
        {
            Console.WriteLine($"Стоимость доставки: {deliveryCost} руб."); 
            Console.WriteLine($"Стоимость заказа:   {orderCost} руб.");
            Console.WriteLine($"ИТОГО К ОПЛАТЕ:     {orderCost + deliveryCost} руб.");
        }
    }
}