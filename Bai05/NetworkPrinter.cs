/****************/
//mã sinh viên: 202418989
//họ tên: Chu Đình Thi
/****************/
using System;

namespace Bai05
{
    //tách riêng lớp máy in mạng kế thừa từ printer và cài đặt inetworkable
    public class NetworkPrinter : Printer, INetworkable
    {
        public string IpAddress { get; private set; }
        public bool IsConnected { get; private set; }

        public NetworkPrinter(string id, string name, int year, decimal price, string type, int pages, bool isColor, DeviceStatus status = DeviceStatus.Active)
            : base(id, name, year, price, type, pages, isColor, status)
        {
            IsConnected = false;
            IpAddress = null;
        }




        //kết nối mạng
        public void Connect(string ip)
        {
            if (string.IsNullOrWhiteSpace(ip)) throw new Exception("địa chỉ ip ko đc để trống.");
            if (IsConnected) throw new Exception("máy in đang nối mạng rồi, ko cắm lại đc.");

            IpAddress = ip;
            IsConnected = true;
        }

        //ngắt kết nối mạng
        public void Disconnect()
        {
            IsConnected = false;
            IpAddress = null;
        }

        public override string ToString()
        {
            string netStr = IsConnected ? $"Đã nối mạng (IP: {IpAddress})" : "Chưa nối mạng";
            return base.ToString() + $" | Mạng: {netStr}";
        }
    }
}
