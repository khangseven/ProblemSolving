using Microsoft.EntityFrameworkCore;
using ProblemSolving.Domain.Entities;
using ProblemSolving.Domain.ValueObjects;

namespace ProblemSolving.Data.Context
{
    public class ProblemSolvingContext : DbContext
    {
        public ProblemSolvingContext(DbContextOptions<ProblemSolvingContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Star> Stars { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Post>().ToTable("Posts");
            modelBuilder.Entity<Post>()
                .HasKey(post => post.Id)
                .HasName("Post_PrimaryKey_PostId");
            modelBuilder.Entity<Post>()
                .Property(post => post.Title)
                .HasColumnType("varchar")
                .HasMaxLength(250)
                .HasConversion(
                    x=>x.Value,
                    x=>Title.Create(x.ToString())
                );
            modelBuilder.Entity<Post>()
                .Property(post => post.Content)
                .HasColumnType("nvarchar")
                .HasMaxLength(1024)
                .HasConversion(
                    x => x.Value,
                    x => Content.Create(x.ToString())
                );

            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<User>()
                .HasKey(user => user.Id)
                .HasName("User_PrimaryKey_UserId");

            modelBuilder.Entity<User>()
                .Property(user => user.FullName)
                .HasColumnType("varchar")
                .HasMaxLength(250)
                .HasConversion(
                    x=> x.Value,
                    x=> FullName.Create(x.ToString())
                );
            modelBuilder.Entity<User>()
                .Property(user => user.UserName)
                .HasColumnType("varchar")
                .HasMaxLength(250)
                .HasConversion(
                    x => x.Value,
                    x => UserName.Create(x.ToString())
                );
            modelBuilder.Entity<User>()
                .Property(user => user.PassWord)
                .HasColumnType("varchar")
                .HasMaxLength(250)
                .HasConversion(
                    x => x.Value,
                    x => PassWord.Create(x.ToString())
                );

            modelBuilder.Entity<Star>()
                .HasKey(star => new { star.Post_Id, star.User_Id });
            modelBuilder.Entity<Star>()
                .HasOne<Post>(star => star.Post)
                .WithMany(post => post.Stars)
                .HasForeignKey(star => star.Post_Id)
                .HasConstraintName("Stars_ForeignKey_PostId");
            modelBuilder.Entity<Star>()
                .HasOne<User>(star => star.User)
                .WithMany(user => user.Stars)
                .HasForeignKey(star => star.User_Id)
                .HasConstraintName("Stars_ForeignKey_UserId");

           // base.OnModelCreating(modelBuilder);
        }
    }
}
