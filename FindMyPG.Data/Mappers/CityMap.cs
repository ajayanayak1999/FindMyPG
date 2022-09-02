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
    public class CityMap : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            //TODO:: Configure CityMap..
            var table = builder.ToTable("City");
                table.HasKey(k => k.Id);
                table
                .HasMany(p => p.PGInfos)
                .WithOne(p => p.City)
                .HasForeignKey(p => p.CityId);
            table
                .HasMany(p => p.ZipCodes)
                .WithOne(p => p.City)
                .HasForeignKey(q => q.CityId);
        }
    }
}
