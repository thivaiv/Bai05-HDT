/****************/
//mã sinh viên: 202418989
//họ tên: Chu Đình Thi
/****************/
using System;

namespace Bai05
{
    //lớp máy chiếu kế thừa từ device
    public class Projector : Device
    {
        public int Brightness { get; set; } //độ sáng đơn vị lumen
        public int LampHours { get; set; } //số giờ bóng đèn đã chiếu

        public Projector(string id, string name, int year, decimal price, int brightness, int lampHours, DeviceStatus status = DeviceStatus.Active)
            : base(id, name, year, price, status)
        {
            Brightness = brightness;
            LampHours = lampHours;
        }

        //công thức: 3% giá mua +1.500.000đ nếu bóng đèn chiếu quá 3000h
        public override decimal CalculateAnnualMaintenanceCost()
        {
            decimal phi = PurchasePrice * 0.03m;

            if (LampHours > 3000)
            {
                phi += 1500000m;
            }

            return phi;
        }

        public override string ToString()
        {
            return base.ToString() + $" | Độ sáng: {Brightness} lumens, Giờ đèn: {LampHours:N0}h";
        }
    }
}
