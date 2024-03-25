using LunaStore.Application.Products.Commands;
using LunaStore.Application.Products.Queries;
using LunaStore.Domain.Entities;
using LunaStore.Domain.Interfaces;
using MediatR;

namespace LunaStore.Application.Products.Handlers
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ProductEntity>
    {
        private readonly IProductRepository _repo;

        public GetProductByIdQueryHandler(IProductRepository productRepository)
        {
            _repo = productRepository ?? throw new ArgumentNullException(nameof(productRepository));

        }
        public async Task<ProductEntity> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            return await _repo.GetByIdAsync(request.Id);
        }
    }
}
