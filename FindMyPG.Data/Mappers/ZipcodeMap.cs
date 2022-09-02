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
    public class ZipcodeMap : IEntityTypeConfiguration<ZipCode>
    {
        public void Configure(EntityTypeBuilder<ZipCode> builder)
        {
           var table= builder.ToTable("ZipCode");
            table
                .HasKey(k => k.Id);
            table
              .HasMany(f => f.PGInfos)
              .WithOne(f => f.ZipCode)
              .HasForeignKey(f => f.ZipId);  
        }
    }
}
