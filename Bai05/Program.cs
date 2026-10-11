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

            Console.WriteLine("=== CHƯƠNG TRÌNH QUẢN LÝ THIẾT BỊ PHÒNG THỰC HÀNH ===");

            //tạo 2 phòng lab thực hành
            LabRoom phongD9 = new LabRoom("LAB_D9", "Phòng Lab Đồ Họa D9", 40);
            LabRoom phongC7 = new LabRoom("LAB_C7", "Phòng Thực Hành Cơ Bản C7", 30);

            //khởi tạo dàn thiết bị theo đề bài
            //hai máy tính, trong đó một máy có gpu rời
            Computer pcDoHoa = new Computer("PC01", "Dàn PC Gaming RTX 5090 Ti", 2024, 85000000m, 64, "Core i9 14900KS", true);
            Computer pcCo = new Computer("PC02", "Máy bàn văn phòng i3 cỏ", 2018, 7000000m, 8, "Core i3 8100", false);

            //hai máy in, trong đó một máy in trên 100k trang, một máy có card mạng
            Printer inCanon = new Printer("PR01", "Canon LBP2900 quốc dân", 2019, 4500000m, "Laser", 125000, false);
            NetworkPrinter inMang = new NetworkPrinter("PR02", "HP LaserJet Pro mạng LAN", 2021, 9500000m, "Laser", 35000, false);

            //một máy chiếu có bóng đèn dùng trên 3000 giờ
            Projector chieuD9 = new Projector("PJ01", "Máy chiếu Sony D9", 2018, 20000000m, 3500, 3800);

            //1. thêm thiết bị vào phòng
            Console.WriteLine("\n--- 1. Thêm thiết bị vào các phòng ---");
            phongD9.AddDevice(pcDoHoa);
            phongD9.AddDevice(inCanon);
            phongD9.AddDevice(chieuD9);

            phongC7.AddDevice(pcCo);
            phongC7.AddDevice(inMang);

            Console.WriteLine(phongD9);
            Console.WriteLine(phongC7);
            Console.WriteLine("=> Đã phân bổ thiết bị vào các phòng thành công.");

            //2. thử thêm thiết bị bị trùng mã
            Console.WriteLine("\n--- 2. Thử thêm thiết bị trùng mã ---");
            try
            {
                //thử nhét lại máy PC01 vào phòng D9
                phongD9.AddDevice(new Computer("PC01", "Máy tính clone", 2023, 10000000m, 16, "i5", false));
            }
            catch (Exception ex)
            {
                Console.WriteLine("Bắt được lỗi: " + ex.Message);
            }

            //3. in danh sách thiết bị trong từng phòng
            Console.WriteLine("\n--- 3. Danh sách thiết bị trong từng phòng ---");
            Console.WriteLine($"[Danh sách {phongD9.RoomName}]");
            foreach (Device d in phongD9.Devices)
            {
                Console.WriteLine(" - " + d);
            }

            Console.WriteLine($"\n[Danh sách {phongC7.RoomName}]");
            foreach (Device d in phongC7.Devices)
            {
                Console.WriteLine(" - " + d);
            }

            //4. tính tổng chi phí bảo trì dự kiến của mỗi phòng (đa hình)
            Console.WriteLine("\n--- 4. Tổng chi phí bảo trì dự kiến ---");
            Console.WriteLine($"Tổng chi phí bảo trì {phongD9.RoomName}: {phongD9.CalculateAnnualMaintenanceCost():N0}đ");
            Console.WriteLine($"Tổng chi phí bảo trì {phongC7.RoomName}: {phongC7.CalculateAnnualMaintenanceCost():N0}đ");

            //5. liệt kê thiết bị cần bảo trì (> 5 năm hoặc trạng thái UnderMaintenance)
            Console.WriteLine("\n--- 5. Thiết bị cần bảo trì ---");
            Console.WriteLine($"Thiết bị cần bảo trì ở {phongD9.RoomName}:");
            foreach (Device d in phongD9.GetDevicesRequiringMaintenance())
            {
                Console.WriteLine($" * {d.Name} ({d.Id}) - Năm mua: {d.YearPutIntoUse}");
            }

            Console.WriteLine($"Thiết bị cần bảo trì ở {phongC7.RoomName}:");
            foreach (Device d in phongC7.GetDevicesRequiringMaintenance())
            {
                Console.WriteLine($" * {d.Name} ({d.Id}) - Năm mua: {d.YearPutIntoUse}");
            }

            //6 & 7. kết nối mạng và duyệt các thiết bị mạng qua INetworkable
            Console.WriteLine("\n--- 6 & 7. Kết nối mạng và duyệt qua Interface INetworkable ---");
            Device[] tatCaThietBi = { pcDoHoa, pcCo, inCanon, inMang, chieuD9 };

            foreach (Device d in tatCaThietBi)
            {
                //duyệt đa hình qua INetworkable, ko phụ thuộc vào lớp cụ thể
                if (d is INetworkable thietBiMang)
                {
                    thietBiMang.Connect("192.168.1." + new Random().Next(10, 99));
                    Console.WriteLine($"[Mạng OK] Thiết bị: {d.Name} | IP cấp: {thietBiMang.IpAddress} | Trạng thái: {thietBiMang.IsConnected}");
                }
            }

            Console.WriteLine("\n=== HOÀN TẤT KỊCH BẢN KIỂM THỬ ===");
        }
    }
}
