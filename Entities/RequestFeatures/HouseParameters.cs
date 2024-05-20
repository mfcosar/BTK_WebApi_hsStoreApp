using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.RequestFeatures
{
    public class HouseParameters: RequestParameters
    {
        public uint MinPrice { get; set; } 
        public uint MaxPrice { get; set; } = 100000;

        public bool ValidPriceRange => MinPrice <= MaxPrice;

        public String? SearchTerm { get; set; }

        public HouseParameters()
        {
            OrderBy = "id"; // HouseRepo'da ID'e göre sıralanıyor, default uyumlu olması için
        }


    }
}
