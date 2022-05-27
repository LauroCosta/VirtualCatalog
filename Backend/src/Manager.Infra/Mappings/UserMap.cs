using Manager.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Manager.Infra.Mappings
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .UseIdentityColumn()
                .HasColumnType("BIGINT");

            builder.Property(x => x.Name)
                .HasColumnType("VARCHAR(80)")
                .IsRequired()
                .HasMaxLength(80)
                .HasColumnName("name");

            builder.Property(x => x.Email)
                .HasColumnType("VARCHAR(180)")
                .IsRequired()
                .HasMaxLength(180)
                .HasColumnName("email");

            builder.Property(x => x.Password)
                .HasColumnType("VARCHAR(30)")
                .IsRequired()
                .HasMaxLength(30)
                .HasColumnName("password");

        }
   
    }
}