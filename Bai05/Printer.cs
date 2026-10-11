/****************/
//mã sinh viên: 202418989
//họ tên: Chu Đình Thi
/****************/
using System;

namespace Bai05
{
    //lớp máy in kế thừa từ device
    public class Printer : Device
    {
        public string PrinterType { get; set; } //laser hoặc phun
        public int PrintedPages { get; set; } //số trang đã cày
        public bool IsColor { get; set; } //máy in màu hay in đen trắng

        public Printer(string id, string name, int year, decimal price, string type, int pages, bool isColor, DeviceStatus status = DeviceStatus.Active)
            : base(id, name, year, price, status)
        {
            PrinterType = type;
            PrintedPages = pages;
            IsColor = isColor;
        }

        //CT: 4% giá + 500k nếu in quá 100k trang( +300k nếu là máy in màu)
        public override decimal CalculateAnnualMaintenanceCost()
        {
            decimal phi = PurchasePrice * 0.04m;

            if (PrintedPages > 100000)
            {
                phi += 500000m;
            }

            if (IsColor)
            {
                phi += 300000m;
            }

            return phi;
        }

        public override string ToString()
        {
            string mauStr = IsColor ? "In màu" : "Đen trắng";
            return base.ToString() + $" | Loại: {PrinterType}, {mauStr}, Đã in: {PrintedPages:N0} trang";
        }
    }
}
