using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects
{
    public record HouseDtoForUpdate(int Id, string Type, decimal Price, string Location)
    {
        /*public int Id { get; init; }
        public string Type { get; init; }
        public decimal Price { get; init;  }
        public string Location { get; init; }*/



    }
}
