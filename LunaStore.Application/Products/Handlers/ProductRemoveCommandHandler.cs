using LunaStore.Application.Products.Commands;
using LunaStore.Domain.Entities;
using LunaStore.Domain.Interfaces;
using MediatR;

namespace LunaStore.Application.Products.Handlers
{
    public class ProductRemoveCommandHandler : IRequestHandler<ProductRemoveCommand, ProductEntity>
    {
        private IProductRepository _repo;
        public ProductRemoveCommandHandler(IProductRepository productRepository)
        {
            _repo = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
        }
        public async Task<ProductEntity> Handle(ProductRemoveCommand request, CancellationToken cancellationToken)
        {
            var product = await _repo.GetByIdAsync(request.Id);
            if (product == null)
            {
                throw new ApplicationException("Error creating entity");
            }
            else
            {
                var result = await _repo.RemoveAsync(product);
                return result;
            }
        }
    }
}
