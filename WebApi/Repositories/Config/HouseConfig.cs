using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApi.Models;

namespace WebApi.Repositories.Config
{
    public class HouseConfig : IEntityTypeConfiguration<House>
    {
        public void Configure(EntityTypeBuilder<House> builder)
        {
            builder.HasData(
                new House { Id = 1, Type = "Ege bungalov",     Price = 4000, Location = "Manisa/Akhisar"},
                new House { Id = 2, Type = "Karadeniz ahşap",  Price = 3000, Location = "Ordu/Ünye" },
                new House { Id = 3, Type = "İçanadolu kerpiç", Price = 2000, Location = "Konya/Ilgın" }
            );
        }
    }
}
