using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public class PriceOutofRangeBadRequestException: BadRequestException
    {
        public PriceOutofRangeBadRequestException() : 
            base("Max.price must be less than 1000 and min. price must be greater than 10")
        {
            
        }
    }
}
