using System;

namespace Delivery
{
    class Program
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
    }
    }
}
