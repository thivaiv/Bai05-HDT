using System;
namespace Bai05
{
    public enum DeviceStatus
    {
        Active,
        UnderMaintenance,
        Retired
    }

    public abstract class Device
    {
        public string Id { get; } 
        public string Name { get; set; }
        public int YearPutIntoUse { get; set; }
        public decimal PurchasePrice { get; set; }
        public DeviceStatus Status { get; set; }

        public Device(string id, string name, int year, decimal price)
        {
            Id = id;
            Name = name;
            YearPutIntoUse = year;
            PurchasePrice = price;
            Status = DeviceStatus.Active; 
        }

        // logic tính toán
        public abstract decimal CalculateAnnualMaintenanceCost();

        public override string ToString()
        {
            return $"Mã: {Id} - Tên: {Name}";
        }
    }
}
