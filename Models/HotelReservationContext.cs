using Microsoft.EntityFrameworkCore;
using HotelReservationSystem.Models;

namespace HotelReservationSystem.Data
{
    public class HotelReservationContext : DbContext
    {
        public HotelReservationContext(DbContextOptions<HotelReservationContext> options) : base(options) { }

        public DbSet<Room> Rooms { get; set; }  // Odalar veri tabanı seti
        public DbSet<Reservation> Reservations { get; set; }  // Rezervasyonlar veri tabanı seti
        public DbSet<User> Users { get; set; }  // Kullanıcılar veri tabanı seti

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Oda tablosu yapılandırması
            modelBuilder.Entity<Room>(entity =>
            {
                entity.ToTable("rooms");
                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Name).HasColumnName("name");
                entity.Property(e => e.Capacity).HasColumnName("capacity");
                entity.Property(e => e.View).HasColumnName("view");
            });

            // Rezervasyon tablosu yapılandırması
            modelBuilder.Entity<Reservation>(entity =>
            {
                entity.ToTable("reservations");
                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.RoomId).HasColumnName("roomid");
                entity.Property(e => e.UserName).HasColumnName("username");
                entity.Property(e => e.StartDate).HasColumnName("startdate");
                entity.Property(e => e.EndDate).HasColumnName("enddate");

                entity.HasOne(d => d.Room)
                      .WithMany(p => p.Reservations)
                      .HasForeignKey(d => d.RoomId);
            });

            // Kullanıcı tablosu yapılandırması
            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users");
                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.UserName).HasColumnName("username");
                entity.Property(e => e.Password).HasColumnName("password");
                entity.Property(e => e.Email).HasColumnName("email");
                entity.Property(e => e.Gender).HasColumnName("gender");
                entity.Property(e => e.Age).HasColumnName("age");
            });
        }
    }
}
