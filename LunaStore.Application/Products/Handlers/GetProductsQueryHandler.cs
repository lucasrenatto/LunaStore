using LunaStore.Application.Products.Queries;
using LunaStore.Domain.Entities;
using LunaStore.Domain.Interfaces;
using MediatR;

namespace LunaStore.Application.Products.Handlers
{
    public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, IEnumerable<ProductEntity>>
    {
        private readonly IProductRepository _repo;

        public GetProductsQueryHandler(IProductRepository productRepository)
        {
            _repo = productRepository ?? throw new ArgumentNullException(nameof(productRepository));

        }

        public async Task<IEnumerable<ProductEntity>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {

            return await _repo.GetAllAsync();
        }
    }
}
