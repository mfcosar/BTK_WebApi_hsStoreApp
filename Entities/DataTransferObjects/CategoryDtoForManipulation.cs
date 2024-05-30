using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects
{
    public abstract record CategoryDtoForManipulation
    {
        [Required(ErrorMessage = "Please enter type of house")]
        [MinLength(2, ErrorMessage = "Please enter type of house min. length of 2")]
        [MaxLength(60, ErrorMessage = "Please enter type of house max. length of 60")]
        public String CategoryName { get; init; }
    }
}
