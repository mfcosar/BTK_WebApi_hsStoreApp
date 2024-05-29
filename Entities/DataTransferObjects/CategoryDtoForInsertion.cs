using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects
{
    public record CategoryDtoForInsertion: CategoryDto
    {
        [Required(ErrorMessage = "Please enter name of Category")]
        [MinLength(2, ErrorMessage = "Please enter name of Category min. length of 2")]
        [MaxLength(60, ErrorMessage = "Please enter name of Category max. length of 60")]
        public String CategoryName { get; init; }
    }
}
