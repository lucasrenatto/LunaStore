using LunaStore.Domain.Entities;
using MediatR;

namespace LunaStore.Application.Products.Commands
{
    public class ProductRemoveCommand : IRequest<ProductEntity>
    {
        public int Id { get; set; }

        public ProductRemoveCommand(int id)
        {
            Id = id;
        }
    }
}
