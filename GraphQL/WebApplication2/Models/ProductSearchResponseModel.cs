using System.Collections.Generic;
using Sundio.Packages.Models;

namespace WebApplication2.Models
{
    public class ProductSearchResponseModel
    {
        public IEnumerable<PackageModelExtended> Results { get; set; }
    }
}