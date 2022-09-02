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
    public class StateMap : IEntityTypeConfiguration<State>
    {
        public void Configure(EntityTypeBuilder<State> builder)
        {
           var table= builder.ToTable("State");
            table
                .HasKey(t => t.Id);
            table
                .HasMany(f => f.PGInfos)
                .WithOne(f => f.State)
                .HasForeignKey(f => f.StateId);
            table
                .HasMany(t => t.Citys)
                .WithOne(t => t.State)
                .HasForeignKey(k => k.StateId);

        }
    }
}
