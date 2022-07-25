using EFCore_Sample.Domain;
using Microsoft.EntityFrameworkCore;

namespace EFCore_Sample.Data;

public class BlogDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=.;Database=BlogDb;Integrated Security=true;" , opt=>
            opt.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasSequence("AutherNumber")
            .StartsAt(1000)
            .IncrementsBy(1);

        modelBuilder.Entity<Author>()
            .ToTable("Author");
        modelBuilder.Entity<AuthorInfo>()
            .ToTable("AuthorInfo");
        
        new DatabaseConfig.TagConfig().Configure(modelBuilder.Entity<Tag>());
        new DatabaseConfig.CategoryConfig().Configure(modelBuilder.Entity<Category>());
        new DatabaseConfig.PostConfig().Configure(modelBuilder.Entity<Post>());
        new DatabaseConfig.AuthorConfig().Configure(modelBuilder.Entity<Author>());
        
        
    }

    public DbSet<Author> Authors  => Set<Author>();
    public DbSet<Category> Categories  => Set<Category>();
    public DbSet<Post> Posts  => Set<Post>();
    public DbSet<PostCategory> PostCategories  => Set<PostCategory>();
    public DbSet<PostTag> PostTags  => Set<PostTag>();
    public DbSet<Tag> Tags  => Set<Tag>();
    public DbSet<Video> Videos  => Set<Video>();
    public DbSet<Article> Articles  => Set<Article>();
}