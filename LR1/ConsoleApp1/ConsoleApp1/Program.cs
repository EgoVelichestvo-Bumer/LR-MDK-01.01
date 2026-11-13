using System;

namespace Delivery
{
    class Program
    {
        static void Main(string[] args)
        {
            // Вызываем функцию ввода стоимости
            double orderCost = GetOrderCost();

            // Вызываем функцию ввода расстояния
            double distance = GetDistance();

            // Вызываем функцию ввода времени
            int hour = GetDeliveryHour();

            // Вычисляем стоимость доставки, передавая полученные данные
            double deliveryCost = CalculateDeliveryCost(orderCost, distance, hour);

            // Выводим итоговый результат
            ShowResult(deliveryCost, orderCost);

            // Задержка, чтобы консоль не закрылась сразу (удобно для новичков)
            Console.WriteLine("Нажмите Enter для выхода...");
            Console.ReadLine();
        }
    }
    }
}