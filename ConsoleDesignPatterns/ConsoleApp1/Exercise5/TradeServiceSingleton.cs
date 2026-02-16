using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.Exercise5
{
    public class TradeServiceSingleton
    {
        // Hidden dependency — no constructor parameter!
        public string ExecuteTrade(string orderId)
        {
            var maxSize = ConfigurationServiceEager.Instance.Get("trade.max.size");
            Console.WriteLine($"Executing trade {orderId} with max size {maxSize}");
            return maxSize!;
        }
    }
}
