/****************/
//mã sinh viên: 202418989
//họ tên: Chu Đình Thi
/****************/
using System;

namespace Bai05
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("=== TEST THỬ INTERFACE INETWORKABLE VÀ NETWORK PRINTER ===");

            //tạo máy tính và máy in có mạng
            Computer pcGaming = new Computer("PC01", "Dàn PC Gaming RTX 5090 Ti", 2024, 85000000m, 64, "Core i9 14900KS", true);
            NetworkPrinter inMang = new NetworkPrinter("PR_NET", "HP LaserJet Pro mạng LAN", 2022, 9500000m, "Laser", 35000, false);
            Printer inThuong = new Printer("PR01", "Canon LBP2900 cắm USB", 2019, 4500000m, "Laser", 125000, false);

            Console.WriteLine("\n--- Trạng thái ban đầu ---");
            Console.WriteLine(pcGaming);
            Console.WriteLine(inMang);
            Console.WriteLine(inThuong);


            Console.WriteLine("\n--- Test cắm mạng ---");
            pcGaming.Connect("192.168.1.10");
            inMang.Connect("192.168.1.55");

            Console.WriteLine("Sau khi cắm dây mạng:");
            Console.WriteLine(pcGaming);
            Console.WriteLine(inMang);

            Console.WriteLine("\n--- Test bắt lỗi mạng ---");
            //thử cắm lại khi đang nối mạng
            try
            {
                pcGaming.Connect("192.168.1.99");
            }
            catch (Exception ex)
            {
                Console.WriteLine("bắt được lỗi cắm đè IP: " + ex.Message);


            }

            //thử nhập ip rỗng
            try
            {
                inMang.Disconnect();
                inMang.Connect("   ");
            }
            catch (Exception ex)
            {
                Console.WriteLine("bắt được lỗi ip rỗng: " + ex.Message);
            }





            //test rút mạng
            Console.WriteLine("\n--- Test rút mạng ---");
            pcGaming.Disconnect();
            Console.WriteLine("Rút mạng PC xong -> Đang nối: " + pcGaming.IsConnected + ", IP: " + (pcGaming.IpAddress ?? "null"));
        }
    }
}
