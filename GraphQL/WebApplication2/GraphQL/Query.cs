using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Data.Sorting;
using Sundio.Packages.Models;
using WebApplication2.Data;
using WebApplication2.Models;
using WebApplication2.Services;

namespace WebApplication2.GraphQL
{
    public class Query
    {
        private readonly PackagesService _service;

        public Query(PackagesService service)
        {
            _service = service;
        }
        // So basically this attribute is pulling a db context from a pool
        // using the db context 
        // returning the db context to the pool
        [UseDbContext(typeof(ApiDbContext))]
        [UseProjection] //=> we have remove it since we have used explicit resolvers
        [UseFiltering]
        [UseSorting]
        public IQueryable<ItemData> GetItems([ScopedService] ApiDbContext context)
        {
            return context.Items;
        }

        [UseDbContext(typeof(ApiDbContext))]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<ItemList> GetLists([ScopedService] ApiDbContext context)
        {
            return context.Lists;
        }

        [UseProjection]
        [UseFiltering]
        [UseSorting(sortingType: typeof(PackageModelSortType))]
        public async Task<IEnumerable<PackageModel>> GetPackages()
        {
            return await _service.GetPackages();
        }
    }

        public class PackageModelSortType : SortInputType<PackageModel>
        {
            protected override void Configure(ISortInputTypeDescriptor<PackageModel> descriptor)
            {
                ISortInputTypeDescriptor<PackageModel> sortInputTypeDescriptor = descriptor.BindFieldsImplicitly();
                sortInputTypeDescriptor.Field(_ => _.BookingRelatedCostsInfo).Ignore();
            }
        }
}
