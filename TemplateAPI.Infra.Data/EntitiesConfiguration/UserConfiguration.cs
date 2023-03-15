using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Template.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template.Infra.Data.EntitiesConfiguration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");

            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("Id");

            builder.Property(p => p.Username).HasColumnType("varchar(50)").HasColumnName("Username").IsRequired();
            builder.Property(p => p.PasswordHash).HasColumnType("varchar(250)").HasColumnName("PasswordHash").IsRequired();
            builder.Property(p => p.Role).HasColumnType("int").HasColumnName("Role").IsRequired();

        }
    }
}
