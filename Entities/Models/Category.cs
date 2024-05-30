using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public String? CategoryName { get; set; }

        //Ref: collection navigation prop.

        //public ICollection<House> Houses { get; set; }
    }
}
