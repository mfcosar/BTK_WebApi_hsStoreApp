using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects
{
    public record HouseDtoForUpdate(int Id, String Type, decimal Price, String Location);
}
