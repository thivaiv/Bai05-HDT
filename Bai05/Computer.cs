/****************/
//mã sinh viên: 202418989
//họ tên: Chu Đình Thi
/****************/
using System;

namespace Bai05
{
    //máy tính luôn có cổng mạng nên kế thừa device và cài đặt inetworkable
    public class Computer : Device, INetworkable
    {
        public int RamCapacity { get; set; }
        public string ProcessorType { get; set; }
        public bool HasDedicatedGpu { get; set; }

        //các thuộc tính mạng từ interface
        public string IpAddress { get; private set; }
        public bool IsConnected { get; private set; }

        public Computer(string id, string name, int year, decimal price, int ram, string cpu, bool gpu, DeviceStatus status = DeviceStatus.Active)
            : base(id, name, year, price, status)
        {
            RamCapacity = ram;
            ProcessorType = cpu;
            HasDedicatedGpu = gpu;
            IsConnected = false;
            IpAddress = null;
        }

        //công thức: 5% giá mua + 2% nếu có gpu rời + 1% nếu xài trên 5 năm
        public override decimal CalculateAnnualMaintenanceCost()
        {
            decimal phi = PurchasePrice * 0.05m;

            if (HasDedicatedGpu)
            {
                phi += PurchasePrice * 0.02m;
            }

            if (DateTime.Now.Year - YearPutIntoUse > 5)
            {
                phi += PurchasePrice * 0.01m;
            }

            return phi;
        }

        //kết nối mạng
        public void Connect(string ip)
        {
            if (string.IsNullOrWhiteSpace(ip)) throw new Exception("địa chỉ ip ko đc để trống.");
            if (IsConnected) throw new Exception("máy đang kết nối mạng rồi, ko cắm lại đc.");

            IpAddress = ip;
            IsConnected = true;
        }

        //ngắt kết nối mạng
        public void Disconnect()
        {
            IsConnected = false;
            IpAddress = null; //ngắt xong là mất ip
        }

        public override string ToString()
        {
            string gpuStr = HasDedicatedGpu ? "Có GPU rời" : "Onboard";
            string netStr = IsConnected ? $"Đã nối mạng (IP: {IpAddress})" : "Chưa nối mạng";
            return base.ToString() + $" | Cấu hình: {RamCapacity}GB RAM, {ProcessorType}, {gpuStr} | Mạng: {netStr}";
        }
    }
}
