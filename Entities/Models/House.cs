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

        //Ref: navigation prop.
        public int CategoryId { get; set; }
        public Category Category { get; set; } //veri tabanında bunun fiziki bir karşılığı olmaz. Sadece int gibi değerlerin olur
    }
}
