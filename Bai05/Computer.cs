using System;
namespace Bai05
{
    public class Computer : Device
    {
        public int RamCapacity { get; set; }
        public string ProcessorType { get; set; }

        public Computer(string id, string name, int year, decimal price, int ram, string cpu)
            : base(id, name, year, price)
        {
            RamCapacity = ram;
            ProcessorType = cpu;
        }

        // nháp thử công thức lấy 5% giá mua
        public override decimal CalculateAnnualMaintenanceCost()
        {
            return PurchasePrice * 0.05m; 
        }
    }
}
