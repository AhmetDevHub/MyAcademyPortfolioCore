using Microsoft.EntityFrameworkCore;
using Portfolio.Web.Entities;

namespace Portfolio.Web.Context
{
	public class PortfolioContext : DbContext
	{
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("server=DESKTOP-1BMQTPK\\SQLEXPRESS; database=MyAcademyPortfolioDb; integrated " +
				"security=true; trustServerCertificate=true");
		}


		//Çoğullaştırma pluralize
		public DbSet<About> Abouts { get; set; }
		public DbSet<Banner> Banners { get; set; }
		public DbSet<Category> Categories { get; set; }
		public DbSet<Education> Educations { get; set; }
		public DbSet<Experience> Experiences { get; set; }
		public DbSet<Project> Projects { get; set; }
		public DbSet<Skill> Skills { get; set; }
		public DbSet<Testimonial> Testimonials { get; set; }
		public DbSet<UserMessage> UserMessage { get; set; }
		public DbSet<ContactInfo> ContactInfo { get; set; }

	}
}
