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
    public class PGInfoMap : IEntityTypeConfiguration<PGInfo>
    {
        public void Configure(EntityTypeBuilder<PGInfo> builder)
        {
            var table = builder.ToTable("PGInfo");
                table
                .HasKey(k => k.Id);
                table
                .HasMany(r => r.PGRooms).
                WithOne(p => p.PGInfo)
                .HasForeignKey(i => i.PGInfoId);
            table
                .HasMany(p => p.PGPackages)
                .WithOne(p => p.PGInfo)
                .HasForeignKey(p => p.PGInfoId);
            table
                .HasMany(p => p.PGBookings)
                .WithOne(p => p.PGInfo)
                .HasForeignKey(p => p.PGInfoId);

        }
    }
}
