using Entities.RequestFeatures;
using Microsoft.AspNetCore.Http;

namespace Entities.DataTransferObjects
{
    public record LinkParameters
    {
        public HouseParameters HouseParameters { get; init; }
        public HttpContext HttpContext { get; init; }
    }
}