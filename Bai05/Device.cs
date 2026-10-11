/****************/
//mã sinh viên: 202418989
//họ tên: Chu Đình Thi
/****************/
using System;

namespace Bai05
{
    //enum trạng thái máy
    public enum DeviceStatus
    {
        Active,
        UnderMaintenance,
        Retired
    }

    //lớp trừu tượng cơ sở cho mọi thiết bị trong phòng lab
    public abstract class Device
    {
        //mã chỉ gán 1 lần lúc khởi tạo, ko cho sửa
        public string Id { get; }

        public string Name { get; set; }

        int namDuaVaoSuDung;
        public int YearPutIntoUse
        {
            get { return namDuaVaoSuDung; }
            set {
                if (value > DateTime.Now.Year) throw new Exception("năm đưa vào sử dụng ko đc ở tương lai.");
                namDuaVaoSuDung = value;
            }
        }

        decimal giaMua;
        public decimal PurchasePrice
        {
            get { return giaMua; }
            set {
                if (value <= 0) throw new Exception("giá mua phải lớn hơn 0 đồng.");
                giaMua = value;
            }
        }

        public DeviceStatus Status { get; set; }

        public Device(string id, string name, int year, decimal price, DeviceStatus status = DeviceStatus.Active)
        {
            if (string.IsNullOrWhiteSpace(id)) throw new Exception("mã thiết bị ko đc rỗng.");
            Id = id;
            Name = name;
            YearPutIntoUse = year;
            PurchasePrice = price;
            Status = status;
        }

        //hàm thuần ảo bắt buộc lớp con phải tự tính tiền bảo trì
        public abstract decimal CalculateAnnualMaintenanceCost();

        public override string ToString()
        {
            return $"[{GetType().Name}] {Id} - {Name} | Năm SD: {YearPutIntoUse} | Giá mua: {PurchasePrice:N0}đ | Trạng thái: {Status}";
        }
    }
}
