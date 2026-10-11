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

            Console.WriteLine("=== TEST THỬ CÁC LỚP THIẾT BỊ VÀ TÍNH PHÍ BẢO TRÌ ===");

            //tạo dàn máy test với đồ công nghệ xịn sò
            Computer pcKhung = new Computer("PC01", "Dàn PC Gaming RTX 5090 Ti", 2024, 85000000m, 64, "Core i9 14900KS", true);
            Computer pcCo = new Computer("PC02", "Máy bàn văn phòng i3 cỏ", 2018, 7000000m, 8, "Core i3 8100", false);

            Printer inCanon = new Printer("PR01", "Canon LBP2900 quốc dân", 2019, 4500000m, "Laser", 125000, false);
            Printer inMau = new Printer("PR02", "Epson L805 in màu studio", 2023, 6500000m, "Phun", 40000, true);

            Projector chieuD9 = new Projector("PJ01", "Máy chiếu hội trường D9", 2019, 20000000m, 3500, 3800);

            //in ra xem thông tin từng con
            Console.WriteLine("\n--- Thông tin thiết bị ---");
            Console.WriteLine(pcKhung);
            Console.WriteLine("-> Chi phí bảo trì 1 năm: " + pcKhung.CalculateAnnualMaintenanceCost().ToString("N0") + "đ");

            Console.WriteLine("\n" + pcCo);
            Console.WriteLine("-> Chi phí bảo trì 1 năm (dùng >5 năm): " + pcCo.CalculateAnnualMaintenanceCost().ToString("N0") + "đ");

            Console.WriteLine("\n" + inCanon);
            Console.WriteLine("-> Chi phí bảo trì 1 năm (in >100k trang): " + inCanon.CalculateAnnualMaintenanceCost().ToString("N0") + "đ");

            Console.WriteLine("\n" + inMau);
            Console.WriteLine("-> Chi phí bảo trì 1 năm (máy in màu): " + inMau.CalculateAnnualMaintenanceCost().ToString("N0") + "đ");

            Console.WriteLine("\n" + chieuD9);
            Console.WriteLine("-> Chi phí bảo trì 1 năm (bóng đèn >3000h): " + chieuD9.CalculateAnnualMaintenanceCost().ToString("N0") + "đ");

            //test thử validate dữ liệu
            Console.WriteLine("\n--- Test thử bắt lỗi nhập linh tinh ---");
            try
            {
                Computer pcLoi = new Computer("PC_ERR", "Máy du hành tương lai", 2099, 10000000m, 16, "M1", false);
            }
            catch (Exception ex)
            {
                Console.WriteLine("bắt được lỗi năm: " + ex.Message);
            }

            try
            {
                Printer inGiaAm = new Printer("PR_ERR", "Máy in tặng kèm", 2022, -500000m, "Laser", 100, false);
            }
            catch (Exception ex)
            {
                Console.WriteLine("bắt được lỗi giá mua: " + ex.Message);
            }
        }
    }
}
