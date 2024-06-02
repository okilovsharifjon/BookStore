using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StoreDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    internal class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder
                .ToTable("book");

            builder
                .Property(p => p.Id)
                .HasColumnName("id")
                .IsRequired();

            builder
                .HasKey(k => k.Id);

            builder
                .Property(p => p.Name)
                .HasColumnName("name")
                .HasColumnType("VARCHAR(200)")
                .IsRequired();

            builder
                .Property(p => p.Price)
                .HasColumnName("price")
                .HasColumnType("MONEY")
                .IsRequired();

            builder
                .Property(p => p.Image)
                .HasColumnName("image")
                .HasColumnType("VARCHAR(500)")
                .IsRequired();

            builder
                .HasOne(p => p.Category)
                .WithMany(p => p.Books)
                .HasForeignKey(fk => fk.CategoryId);

            builder
            .Property(p => p.CategoryId)
            .HasColumnName("category_id");

            builder
                .HasOne(p => p.Author)
                .WithMany(p => p.Books)
                .HasForeignKey(fk => fk.AuthorId);
            builder
            .Property(p => p.AuthorId)
            .HasColumnName("author_id");


        }
    }
}
