using LunaStore.Application.Products.Commands;
using LunaStore.Domain.Entities;
using LunaStore.Domain.Interfaces;
using MediatR;

namespace LunaStore.Application.Products.Handlers
{
    public class ProductUpdateCommandHandler : IRequestHandler<ProductUpdateCommand, ProductEntity>
    {
        private IProductRepository _repo;
        public ProductUpdateCommandHandler(IProductRepository productRepository)
        {
            _repo = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
        }

        public async Task<ProductEntity> Handle(ProductUpdateCommand request, CancellationToken cancellationToken)
        {
            var product = await _repo.GetByIdAsync(request.Id);

            if (product == null)
            {
                throw new ApplicationException("Error creating entity");
            }
            else
            {
                product.Update(request.Name, request.Description, request.Price, request.Stock, request.Image, request.CategoryId);
                return await _repo.UpdateAsync(product);
            }
        }
    }
}
