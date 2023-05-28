using System;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using ehotels_data.Models;

namespace ehotels_data.DataAccess
{
	public class EhotelsDbContext: DbContext
	{
		public EhotelsDbContext(DbContextOptions options): base(options) { }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			//var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
			//var connectionString = configuration.GetConnectionString("Default");
			string connectionString = "Host=localhost;Database=ehotels;Username={0};Password={1}";
			string? username = Environment.GetEnvironmentVariable("EHOTELS_DB_USER");
			string? password = Environment.GetEnvironmentVariable("EHOTELS_DB_PASSWORD");
			connectionString = String.Format(connectionString, username, password);
			optionsBuilder.UseNpgsql(connectionString);
        }

		public DbSet<HotelChain> HotelChains { get; set; }
		public DbSet <Hotel> Hotels { get; set; }
		public DbSet <Address> Addresses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<HotelChain>(entity =>
			{
				entity.ToTable("chains");
				entity.HasKey(e => e.Id);
				entity.Property(e => e.Id).HasColumnName("chain_id");
				entity.Property(e => e.Name).HasColumnName("chain_name");
				entity.Property(e => e.NumHotels).HasColumnName("num_hotels");

				entity.HasMany(e => e.Hotels).WithOne(e => e.HotelChain).HasForeignKey(e => e.HotelChainId);
			});

			modelBuilder.Entity<Hotel>(entity =>
			{
				entity.ToTable("hotels");
				entity.HasKey(e => e.Id);
				entity.Property(e => e.Id).HasColumnName("hotel_id");
				entity.Property(e => e.Stars).HasColumnName("stars`");
				entity.Property(e => e.NumRooms).HasColumnName("num_rooms");
				entity.OwnsOne(e => e.Address);
			});
		}
	}
}

