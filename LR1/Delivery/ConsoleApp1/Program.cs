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
        }

}
}
