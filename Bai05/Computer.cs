/****************/
//mã sinh viên: 202418989
//họ tên: Chu Đình Thi
/****************/
using System;

namespace Bai05
{
    //lớp máy tính kế thừa từ device
    public class Computer : Device
    {
        public int RamCapacity { get; set; } //đơn vị gb
        public string ProcessorType { get; set; } //cpu ví dụ core i9 14900ks
        public bool HasDedicatedGpu { get; set; } //có card rời hay ko vd rtx 5090 ti

        public Computer(string id, string name, int year, decimal price, int ram, string cpu, bool gpu, DeviceStatus status = DeviceStatus.Active)
            : base(id, name, year, price, status)
        {
            RamCapacity = ram;
            ProcessorType = cpu;
            HasDedicatedGpu = gpu;
        }

        //công thức: 5% giá mua + 2% nếu có gpu rời + 1% nếu xài trên 5 năm
        public override decimal CalculateAnnualMaintenanceCost()
        {
            decimal phi = PurchasePrice * 0.05m;

            if (HasDedicatedGpu)
            {
                phi += PurchasePrice * 0.02m;
            }

            //check nếu máy chạy quá 5 năm thì cộng thêm 1%
            if (DateTime.Now.Year - YearPutIntoUse > 5)
            {
                phi += PurchasePrice * 0.01m;
            }

            return phi;
        }

        public override string ToString()
        {
            string gpuStr = HasDedicatedGpu ? "Có GPU rời" : "Onboard";
            return base.ToString() + $" | Cấu hình: {RamCapacity}GB RAM, {ProcessorType}, {gpuStr}";
        }
    }
}
