using AutoMapper;
using LunaStore.Application.DTOs;
using LunaStore.Application.Interfaces;
using LunaStore.Application.Products.Commands;
using LunaStore.Application.Products.Queries;
using LunaStore.Domain.Entities;
using MediatR;

namespace LunaStore.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        public ProductService(IMapper mapper, IMediator mediator)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductDTO>> GetAllAsync()
        {
            var productsQuery = new GetProductsQuery();

            if (productsQuery == null)
                throw new Exception($"Entity could not be loaded.");

            var result = await _mediator.Send(productsQuery);

            return _mapper.Map<IEnumerable<ProductDTO>>(result);
        }

        public async Task<ProductDTO> GetByIdAsync(int? id)
        {
            var productByIdQuery = new GetProductByIdQuery(id.Value);

            if (productByIdQuery == null)
                throw new Exception($"Entity could not be loaded.");

            var result = await _mediator.Send(productByIdQuery);

            return _mapper.Map<ProductDTO>(result);
        }

        public async Task<ProductDTO> GetProductCategory(int? id)
        {
            var productByIdQuery = new GetProductByIdQuery(id.Value);

            if (productByIdQuery == null)
                throw new Exception($"Entity could not be loaded.");

            var result = await _mediator.Send(productByIdQuery);

            return _mapper.Map<ProductDTO>(result);
        }

        public async Task AddAsync(ProductDTO productDto)
        {
            var productCreateCommand = _mapper.Map<ProductCreateCommand>(productDto);
            await _mediator.Send(productCreateCommand);
        }

        public async Task UpdateAsync(ProductDTO productDto)
        {
            var productUpdateCommand = _mapper.Map<ProductUpdateCommand>(productDto);
            await _mediator.Send(productUpdateCommand);
        }

        public async Task DeleteAsync(int? id)
        {
            var productRemoveCommand = new ProductRemoveCommand(id.Value);
            if (productRemoveCommand == null)
                throw new Exception($"Entity could not be loaded.");

            await _mediator.Send(productRemoveCommand);
        }
    }
}
