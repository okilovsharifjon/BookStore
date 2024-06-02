using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using StoreDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    internal class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder
                .ToTable("category");

            builder
                .Property(p => p.Id)
                .HasColumnName("id")
                .IsRequired();

            builder
                .HasKey(k => k.Id);

            builder
                .Property(p => p.Name)
                .HasColumnName("name")
                .HasColumnType("VARCHAR(50)")
                .IsRequired();

            builder.HasMany(c => c.Books)
               .WithOne(bc => bc.Category)
               .HasForeignKey(bc => bc.CategoryId)
               .IsRequired();
        }
    }
}
