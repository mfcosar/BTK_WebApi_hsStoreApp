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
        public string Type { get; set; }
        public decimal Price { get; set; }
        public string Location { get; set; }
    }
}
