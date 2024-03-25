using LunaStore.Application.Products.Commands;
using LunaStore.Domain.Entities;
using LunaStore.Domain.Interfaces;
using MediatR;

namespace LunaStore.Application.Products.Handlers
{
    public class ProductCreateCommandHandler : IRequestHandler<ProductCreateCommand, ProductEntity>
    {
        private readonly IProductRepository _repo;

        public ProductCreateCommandHandler(IProductRepository productRepository)
        {
            _repo = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
        }

        public async Task<ProductEntity> Handle(ProductCreateCommand request, CancellationToken cancellationToken)
        {
            var product = new ProductEntity(request.Name, request.Description, request.Price, request.Stock, request.Image);
            if (product == null)
            {
                throw new ApplicationException("Error creating entity");
            }
            else
            {
                product.CategoryId = request.CategoryId;
                return await _repo.CreateAsync(product);
            }
        }
    }
}
