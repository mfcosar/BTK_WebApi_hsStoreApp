using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class House
    {
        public int Id { get; set; }
        public String Type { get; set; }
        public decimal Price { get; set; }
        public String Location { get; set; }
    }
}
