using LunaStore.Domain.Entities;
using MediatR;

namespace LunaStore.Application.Products.Queries
{
    public class GetProductsQuery : IRequest<IEnumerable<ProductEntity>>
    {
    }
}
