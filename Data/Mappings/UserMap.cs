using Cinema.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cinema.Data.Mappings
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");

            builder.HasKey(x=>x.Id);

            builder.Property(x=>x.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

            builder.Property(x=>x.Name)
                .IsRequired()
                .HasColumnName("Name")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(40);
            
            builder.Property(x=>x.Password)
                .IsRequired()
                .HasColumnName("Password")
                .HasColumnType("VARCHAR")
                .HasMaxLength(40);
            
            builder.Property(x=>x.Role)
                .HasColumnName("Role")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(40);
        }
    }
}