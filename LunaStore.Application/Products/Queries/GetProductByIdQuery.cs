using LunaStore.Domain.Entities;
using MediatR;

namespace LunaStore.Application.Products.Queries
{
    public class GetProductByIdQuery : IRequest<ProductEntity>
    {
        public int Id { get; set; }
        public GetProductByIdQuery(int? id)
        {
                Id = id ?? 0;
        }
    }
}
