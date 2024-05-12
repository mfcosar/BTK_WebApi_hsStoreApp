using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects
{
    public abstract record HouseDtoForManipulation
    {
        [Required(ErrorMessage = "Please enter type of house")]
        [MinLength(2, ErrorMessage = "Please enter type of house min. length of 2")]
        [MaxLength(60, ErrorMessage = "Please enter type of house max. length of 60")]
        public String Type { get; init; }



        [Required(ErrorMessage = "Please enter price of house")]
        [Range(1000, 100000)] //ErrorMessage = "Please enter price of house in the range of 1000 to 100,000"
        public decimal Price { get; init; }

        public String Location { get; init; }
    }
}
