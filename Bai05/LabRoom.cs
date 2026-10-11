/****************/
//mã sinh viên: 202418989
//họ tên: Chu Đình Thi
/****************/
using System;
using System.Collections.Generic;

namespace Bai05
{
    //lớp quản lý phòng thực hành (quan hệ kết tập với device)
    public class LabRoom
    {
        public string RoomId { get; set; }   //mã phòng
        public string RoomName { get; set; } //tên phòng
        public int Capacity { get; set; }      //sức chứa máy

        //danh sách thiết bị trong phòng
        public List<Device> Devices { get; set; }

        public LabRoom(string id, string name, int capacity)
        {
            if (string.IsNullOrWhiteSpace(id)) throw new Exception("mã phòng ko đc để trống.");
            RoomId = id;
            RoomName = name;
            Capacity = capacity;
            Devices = new List<Device>();
        }

        //thêm thiết bị vào phòng
        public void AddDevice(Device device)
        {
            // null check
            if (device == null) throw new Exception("thiết bị ko đc null.");

            //ko thêm 2 thiết bị trùng mã vào cùng 1 phòng
            foreach (Device d in Devices)
            {
                if (d.Id == device.Id)
                {
                    throw new Exception($"mã thiết bị {device.Id} đã tồn tại trong phòng {RoomName}.");
                }
            }

            Devices.Add(device);
        }

        //xóa thiết bị khỏi phòng theo mã
        public bool RemoveDevice(string deviceId)
        {
            Device timThay = FindDevice(deviceId);
            if (timThay != null)
            {
                Devices.Remove(timThay);
                return true;
            }
            return false;
        }

        //tìm thiết bị theo mã
        public Device FindDevice(string deviceId)
        {
            foreach (Device d in Devices)
            {
                if (d.Id == deviceId) return d;
            }
            return null;
        }



        //
        //tính tổng chi phí bảo trì dự kiến của cả phòng
        // gọi CalculateAnnualMaintenanceCost() trên từng device
        //
        public decimal CalculateAnnualMaintenanceCost()
        {
            decimal tongChiPhi = 0;
            foreach (Device d in Devices)
            {
                tongChiPhi += d.CalculateAnnualMaintenanceCost();
            }
            return tongChiPhi;
        }

        //lấy danh sách thiết bị cần bảo trì: đang UnderMaintenance hoặc dùng trên 5 năm
        public List<Device> GetDevicesRequiringMaintenance()
        {
            List<Device> dsCanBaoTri = new List<Device>();
            int namHienTai = DateTime.Now.Year;

            foreach (Device d in Devices)
            {
                bool dangHong = d.Status == DeviceStatus.UnderMaintenance;
                bool quaHan5Nam = (namHienTai - d.YearPutIntoUse) > 5;

                if (dangHong || quaHan5Nam)
                {
                    dsCanBaoTri.Add(d);
                }
            }

            return dsCanBaoTri;
        }
        //


        public override string ToString()
        {
            return $"Phòng: {RoomId} - {RoomName} (Sức chứa: {Capacity} chỗ, Hiện có: {Devices.Count} thiết bị)";
        }
    }
}
