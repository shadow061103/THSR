﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using Microsoft.EntityFrameworkCore;
using THSR.Repository.Models.Entities;

namespace THSR.Repository.Models.Context
{
    public partial class THSRContext : DbContext
    {
        public THSRContext()
        {
        }

        public THSRContext(DbContextOptions<THSRContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Fare> Fare { get; set; }
        public virtual DbSet<GeneralTimetable> GeneralTimetable { get; set; }
        public virtual DbSet<RailStopTime> RailStopTime { get; set; }
        public virtual DbSet<Station> Station { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Fare>(entity =>
            {
                entity.HasKey(e => new { e.OriginStationID, e.DestinationStationID });

                entity.HasComment("票價資料");

                entity.Property(e => e.OriginStationID)
                    .HasMaxLength(20)
                    .HasComment("起點車站代碼");

                entity.Property(e => e.DestinationStationID)
                    .HasMaxLength(20)
                    .HasComment("迄點車站代碼");

                entity.Property(e => e.BusinessFare)
                    .HasColumnType("decimal(18, 0)")
                    .HasComment("商務車廂票價");

                entity.Property(e => e.Direction).HasComment("行駛方向 : [0:'南下',1:'北上']");

                entity.Property(e => e.FreeFare)
                    .HasColumnType("decimal(18, 0)")
                    .HasComment("自由座車廂票價");

                entity.Property(e => e.StandardFare)
                    .HasColumnType("decimal(18, 0)")
                    .HasComment("標準車廂票價");

                entity.Property(e => e.UpdateTime)
                    .HasColumnType("datetime")
                    .HasComment("更新時間");
            });

            modelBuilder.Entity<GeneralTimetable>(entity =>
            {
                entity.HasKey(e => e.TrainNo);

                entity.Property(e => e.TrainNo)
                    .HasMaxLength(10)
                    .HasComment("車次代碼");

                entity.Property(e => e.Direction).HasComment("行駛方向 : [0:'南下',1:'北上'] ");

                entity.Property(e => e.EndingStationID)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasComment("列車終點車站代號 ");

                entity.Property(e => e.ServiceFriday).HasComment("星期五是否營運");

                entity.Property(e => e.ServiceMonday).HasComment("星期一是否營運");

                entity.Property(e => e.ServiceSaturday).HasComment("星期六是否營運");

                entity.Property(e => e.ServiceSunday).HasComment("星期日是否營運");

                entity.Property(e => e.ServiceThursday).HasComment("星期四是否營運");

                entity.Property(e => e.ServiceTuesday).HasComment("星期二是否營運");

                entity.Property(e => e.ServiceWednesday).HasComment("星期三是否營運");

                entity.Property(e => e.StartingStationID)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasComment(" 列車起點車站代號");

                entity.Property(e => e.UpdateTime)
                    .HasColumnType("datetime")
                    .HasComment("資料更新時間");
            });

            modelBuilder.Entity<RailStopTime>(entity =>
            {
                entity.HasKey(e => e.Sn);

                entity.HasComment("車次靠站順序");

                entity.Property(e => e.Sn).HasComment("流水號");

                entity.Property(e => e.ArrivalTime)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasComment("到站時間");

                entity.Property(e => e.DepartureTime)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasComment("離站時間");

                entity.Property(e => e.StationID)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasComment("車站代碼");

                entity.Property(e => e.StopSequence).HasComment("跑法站序(由1開始) ");

                entity.Property(e => e.TrainNo)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasComment("車次代碼");

                entity.HasOne(d => d.TrainNoNavigation)
                    .WithMany(p => p.RailStopTime)
                    .HasForeignKey(d => d.TrainNo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RailStopTime_GeneralTimetable");
            });

            modelBuilder.Entity<Station>(entity =>
            {
                entity.HasComment("車站資料");

                entity.Property(e => e.StationID)
                    .HasMaxLength(20)
                    .HasComment("車站代碼");

                entity.Property(e => e.LocationCity)
                    .HasMaxLength(10)
                    .HasComment("車站位置所屬縣市");

                entity.Property(e => e.LocationCityCode)
                    .HasMaxLength(10)
                    .HasComment("車站位置所屬縣市代碼");

                entity.Property(e => e.LocationTown)
                    .HasMaxLength(10)
                    .HasComment("車站位置所屬鄉鎮");

                entity.Property(e => e.LocationTownCode)
                    .HasMaxLength(10)
                    .HasComment("車站位置所屬鄉鎮代碼");

                entity.Property(e => e.PositionLat).HasComment("位置緯度");

                entity.Property(e => e.PositionLon).HasComment("位置經度");

                entity.Property(e => e.StationAddress)
                    .HasMaxLength(50)
                    .HasComment("車站地址");

                entity.Property(e => e.StationCode)
                    .HasMaxLength(20)
                    .HasComment("車站簡碼(訂票系統用)");

                entity.Property(e => e.StationEnName)
                    .HasMaxLength(20)
                    .HasComment(" 車站英文名稱");

                entity.Property(e => e.StationName)
                    .HasMaxLength(20)
                    .HasComment("車站名稱");

                entity.Property(e => e.StationUID)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasComment("車站唯一識別代碼");

                entity.Property(e => e.UpdateTime)
                    .HasColumnType("datetime")
                    .HasComment("更新時間");
            });
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}