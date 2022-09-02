using FindMyPG.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindMyPG.Data.Mappers
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            var table = builder.ToTable("User");
            table
                .HasKey(t => t.Id);
            table
                .HasOne(p => p.PGBooking)
                .WithOne(p => p.User)
                .HasForeignKey<PGBooking>(k => k.SeekerID);

            table
                .HasMany(f => f.PGInfos)
                .WithOne(f => f.User)
                .HasForeignKey(k => k.OwnerId);

        }
    }
}
