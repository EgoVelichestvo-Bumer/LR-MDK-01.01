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
