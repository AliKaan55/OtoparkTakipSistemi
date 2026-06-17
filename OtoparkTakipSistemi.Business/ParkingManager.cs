using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using OtoparkTakipSistemi.DataAccess;
using OtoparkTakipSistemi.Core;

namespace OtoparkTakipSistemi.Business
{
    public class ParkingManager
    {
        public string CheckIn(string licensePlate, VehicleType vehicleType, int selectedSlotId)
        {
            using (var context = new OtoparkDbContext())
            {
                var slot = context.ParkingSlots.Find(selectedSlotId);
                if (slot == null)
                {
                    return "Seçilen park yeri geçersiz!";
                }

                if (slot.IsFull)
                {
                    return $"Giriş Engellendi: {slot.SlotNumber} park yeri tamamen doludur! (Kapasite: {slot.Capacity})";
                }

                var record = new ParkingRecord
                {
                    LicensePlate = licensePlate.ToUpper().Replace(" ", ""), 
                    VehicleType = vehicleType,
                    ParkingSlotId = selectedSlotId,
                    CheckInTime = DateTime.Now,
                    IsActive = true,
                    
                };

                slot.OccupiedCount += 1;

                context.ParkingRecords.Add(record);
                context.SaveChanges();

                return $"Araç girişi başarıyla yapıldı. Park Yeri: {slot.SlotNumber} (Kalan Boş Yer: {slot.AvailableCount}/{slot.Capacity})";
            }
        }

        public decimal CalculatePrice(DateTime checkIn, DateTime checkOut, VehicleType type)
        {
            using (var context = new OtoparkDbContext())
            {
                var tariff = context.Tariffs.FirstOrDefault();
                if (tariff == null) return 0;

                TimeSpan duration = checkOut - checkIn;
                double totalHours = duration.TotalHours;
                if (totalHours <= 1)
                {
                    return tariff.BasePrice * GetVehicleCoefficient(type);
                }
                int extraHours = (int)Math.Ceiling(totalHours - 1); 
                decimal totalPrice = tariff.BasePrice + (extraHours * tariff.HourlyPrice);

                return totalPrice * GetVehicleCoefficient(type);
            }
        }
        public string CheckOut(int recordId)
        {
            using (var context = new OtoparkDbContext())
            {
                var record = context.ParkingRecords
                                    .Include(r => r.ParkingSlot)
                                    .FirstOrDefault(r => r.Id == recordId && r.IsActive);
                if (record == null)
                {
                    return "Aktif park kaydı bulunamadı!";
                }
                record.CheckOutTime = DateTime.Now;

                record.TotalPrice = CalculatePrice(record.CheckInTime, record.CheckOutTime.Value, record.VehicleType);

                record.IsActive = false;
                if (record.ParkingSlot.OccupiedCount > 0)
                {
                    record.ParkingSlot.OccupiedCount -= 1;
                }

                context.SaveChanges();

                return $"Araç Çıkışı Yapıldı! Ödenecek Tutar: {record.TotalPrice:C2}";
            }
        }
        private decimal GetVehicleCoefficient(VehicleType type)
        {
            return type switch
            {
                VehicleType.Motorsiklet => 0.75m, 
                VehicleType.Otomobil => 1.0m,  
                VehicleType.Kamyon => 1.5m,       
                VehicleType.Otobüs => 2.0m,         
                _ => 1.0m
            };
        }

        public List<ParkingSlot> GetEmptySlots()
        {
            using (var context = new OtoparkDbContext())
            {
                return context.ParkingSlots.Where(s => s.OccupiedCount < s.Capacity).ToList();
            }
        }

        public List<ParkingSlot> GetAllSlots()
        {
            using (var context = new OtoparkDbContext())
            {
                return context.ParkingSlots.OrderBy(s => s.SlotNumber).ToList();
            }
        }

        public List<ParkingRecord> GetActiveRecords()
        {
            using (var context = new OtoparkDbContext())
            {
                return context.ParkingRecords.Include(r => r.ParkingSlot).Where(r => r.IsActive).ToList();
            }
        }

        public int GetTotalSlotCount()
        {
            using (var context = new OtoparkDbContext())
            {
                return context.ParkingSlots.Sum(s => s.Capacity);
            }
        }

        public int GetEmptySlotCount()
        {
            using (var context = new OtoparkDbContext())
            {
                return context.ParkingSlots.Sum(s => s.Capacity - s.OccupiedCount);
            }
        }
    }
}
