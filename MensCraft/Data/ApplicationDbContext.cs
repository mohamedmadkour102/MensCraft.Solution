using MensCraft.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : IdentityDbContext<User, IdentityRole<int>, int>
{
	public DbSet<Craftsman> Craftsmen { get; set; }
	public DbSet<Customer> Customers { get; set; }
	public DbSet<City> Cities { get; set; }
	public DbSet<Occupation> Occupations { get; set; }
	public DbSet<Apartment> Apartments { get; set; }

	public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
		: base(options)
	{
	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		base.OnModelCreating(modelBuilder);

		// إعداد TPT (كل كلاس ليه جدول منفصل)
		modelBuilder.Entity<User>().ToTable("Users");
		modelBuilder.Entity<Craftsman>().ToTable("Craftsmen");
		modelBuilder.Entity<Customer>().ToTable("Customers");

		// العلاقات
		modelBuilder.Entity<Craftsman>()
			.HasOne(c => c.City)
			.WithMany()
			.HasForeignKey(c => c.CityId);

		modelBuilder.Entity<Craftsman>()
			.HasOne(c => c.Occupation)
			.WithMany()
			.HasForeignKey(c => c.OccupationId);

		modelBuilder.Entity<Customer>()
			.HasOne(c => c.Location)
			.WithMany()
			.HasForeignKey(c => c.LocationId);

		modelBuilder.Entity<Customer>()
			.HasOne(c => c.Apartment)
			.WithMany()
			.HasForeignKey(c => c.ApartmentId);




		modelBuilder.Entity<City>().HasData(
			new City { Id = 1, Name = "Cairo" },
			new City { Id = 2, Name = "Alexandria" },
			new City { Id = 3, Name = "Giza" }
		);

		modelBuilder.Entity<Apartment>().HasData(
			new Apartment { Id = 1, Name = "Apartment A" },
			new Apartment { Id = 2, Name = "Apartment B" },
			new Apartment { Id = 3, Name = "Apartment C" }
		);

		modelBuilder.Entity<Occupation>().HasData(
			new Occupation { Id = 1, Name = "Electrician" },
			new Occupation { Id = 2, Name = "Plumber" },
			new Occupation { Id = 3, Name = "Carpenter" }
		);
	}
}