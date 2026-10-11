/****************/
//mã sinh viên: 202418989
//họ tên: Chu Đình Thi
/****************/
using System;

namespace Bai05
{
    //interface biểu diễn khả năng kết nối mạng
    public interface INetworkable
    {
        string IpAddress { get; } //địa chỉ ip đang hoạt động
        bool IsConnected { get; } //trạng thái mạng true hoặc false
        
        void Connect(string ipAddress); //cắm mạng vào
        void Disconnect(); //rút dây mạng ra
    }
}
