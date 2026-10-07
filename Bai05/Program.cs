using System;

namespace Bai05
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("--- test  ---");
            
            // test 
            Computer may1 = new Computer("C01", "PC Test", 2023, 10000000m, 8, "Core i7");
            
            Console.WriteLine("Thông tin máy: " + may1.ToString());
            Console.WriteLine("Tiền bảo trì : " + may1.CalculateAnnualMaintenanceCost());
        }
    }
}
