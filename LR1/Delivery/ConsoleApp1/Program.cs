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
    }
    }
}
