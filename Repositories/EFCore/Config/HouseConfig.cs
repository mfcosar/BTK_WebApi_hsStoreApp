using Entities.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EFCore.Config
{
    public class HouseConfig : IEntityTypeConfiguration<House>
    {
        public void Configure(EntityTypeBuilder<House> builder)
        {
            builder.HasData(
                new House { Id = 1, Type = "Ege bungalov", Price = 4000, Location = "Manisa/Akhisar" },
                new House { Id = 2, Type = "Karadeniz ahşap", Price = 3000, Location = "Ordu/Ünye" },
                new House { Id = 3, Type = "İçanadolu kerpiç", Price = 2000, Location = "Konya/Ilgın" }
            );
        }
    }
}
