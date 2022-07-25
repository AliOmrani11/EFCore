using EFCore_Sample.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCore_Sample.Data;

public static class DatabaseConfig
{
    public  class CategoryConfig : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Category");
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Id)
                .ValueGeneratedOnAdd();

            builder.Property(s => s.Title)
                .HasColumnType("Varchar(250)")
                .HasComment("Category Name")
                .IsRequired();

            builder.Property(s => s.InsertedDate)
                .HasDefaultValueSql("GETDATE()");


            builder.HasMany(s => s.Posts)
                .WithMany(s => s.Categories)
                .UsingEntity<PostCategory>(
                    
                    j =>
                        j.HasOne(s => s.Post)
                            .WithMany(s => s.PostCategories)
                            .HasForeignKey(s => s.PostId),
                    
                    j => 
                        j.HasOne(s => s.Category)
                        .WithMany(s => s.PostCategories)
                        .HasForeignKey(s => s.CategoryId),


                    j =>
                    {
                        j.ToTable("PostCategory");
                        j.Property(s => s.InsertedDate)
                            .HasDefaultValueSql("GETDATE()");
                    }
                );
        }
    }
    
    public  class TagConfig : IEntityTypeConfiguration<Tag>
    {
        public void Configure(EntityTypeBuilder<Tag> builder)
        {
            builder.ToTable("Tag");
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Id)
                .ValueGeneratedOnAdd();

            builder.Property(s => s.Title)
                .HasColumnType("Varchar(250)")
                .HasComment("Category Name")
                .IsRequired();



            builder.HasMany(s => s.Posts)
                .WithMany(s => s.Tags)
                .UsingEntity<PostTag>(
                    
                    j =>
                        j.HasOne(s => s.Post)
                            .WithMany(s => s.PostTags)
                            .HasForeignKey(s => s.PostId),
                    
                    j => 
                        j.HasOne(s => s.Tag)
                            .WithMany(s => s.PostTags)
                            .HasForeignKey(s => s.TagId),
                    j=>j.ToTable("PostTag")
                );
        }
    }
    
    public class AuthorConfig : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.ToTable("Author");
            builder.HasKey(s => s.Id);

            builder.Property(s => s.FirstName)
                .HasColumnType("Varchar(250)")
                .IsRequired();
            
            builder.Property(s => s.LastName)
                .HasColumnType("Varchar(250)")
                .IsRequired();

            builder.Property(s => s.DisplayName)
                .HasComputedColumnSql("[FirstName] + ' ' + [LastName]");

            builder.HasIndex(s => new { s.FirstName, s.LastName })
                .IsUnique()
                .HasDatabaseName("Name_Index");

            builder.Property(s => s.Number)
                .HasDefaultValueSql("NEXT VALUE FOR AutherNumber");
        }
    }

    public class PostConfig : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.HasKey(s => s.PostId);

            builder.Property(s => s.InsertedDate)
                .HasDefaultValueSql("GETDATE()");
            builder.Property(s => s.Title)
                .IsRequired()
                .HasColumnType("VARCHAR(500)");

            builder.Property(s => s.IsDeleted)
                .HasDefaultValueSql("0");


            builder.HasIndex(s => s.Title)
                .IsUnique()
                .HasDatabaseName("Title_Index")
                .HasFilter("[IsDeleted] = 0 ");

            builder
                .HasDiscriminator<string>("Type");

            builder.Property("Type")
                .HasColumnType("VARCHAR(500)");

            builder.HasQueryFilter(s => !s.IsDeleted);
        }
    }

}