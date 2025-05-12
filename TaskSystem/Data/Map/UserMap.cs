using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using TaskSystem.Models;

namespace TaskSystem.Data.Map
{
    [ExcludeFromCodeCoverage]
    public class UserMap : IEntityTypeConfiguration<UserModel>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<UserModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Email).IsRequired().HasMaxLength(150);
        }
    }
}
