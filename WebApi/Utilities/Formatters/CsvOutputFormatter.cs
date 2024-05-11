using Entities.DataTransferObjects;
using Entities.Models;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Net.Http.Headers;
using System.Text;

namespace WebApi.Utilities.Formatters
{
    public class CsvOutputFormatter : TextOutputFormatter
    {
        public CsvOutputFormatter()
        {
            SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse("text/csv"));
            SupportedEncodings.Add(Encoding.UTF8);
            SupportedEncodings.Add(Encoding.Unicode);
        }

        protected override bool CanWriteType(Type? type)
        {
            if (typeof(HouseDto).IsAssignableFrom(type) ||
                typeof(IEnumerable<HouseDto>).IsAssignableFrom(type))
            {
                return base.CanWriteType(type);
            }
            return false;
        }
        private static void FormatCsv(StringBuilder buffer, HouseDto house)
        {
            buffer.AppendLine($"{house.Id}, {house.Type}, {house.Price}, {house.Location}");
        }

        public override async Task WriteResponseBodyAsync(OutputFormatterWriteContext context,
            Encoding selectedEncoding)
        {
            var response = context.HttpContext.Response;
            var buffer = new StringBuilder();

            if (context.Object is IEnumerable<HouseDto>)
            {
                foreach (var house in (IEnumerable<HouseDto>)context.Object)
                {
                    FormatCsv(buffer, house);
                }
            }
            else
            {
                FormatCsv(buffer, (HouseDto)context.Object);
            }
            await response.WriteAsync(buffer.ToString());
        }
    }
}