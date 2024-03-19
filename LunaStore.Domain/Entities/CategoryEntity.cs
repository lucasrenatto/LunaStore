using LunaStore.Domain.Validation;

namespace LunaStore.Domain.Entities
{
    public sealed class CategoryEntity : BaseEntity
    {
        public string Name { get; private set; }

        public CategoryEntity(string name)
        {
            ValidateDomain(name);
        }

        public CategoryEntity(int id, string name)
        {
            DomainExceptionValidation.When(id < 0, "Invalid Id value!");
            Id = id;
            ValidateDomain(name);
        }

        public void Update(string name)
        {
            ValidateDomain(name);
        }

        public ICollection<ProductEntity> Products { get; set; }

        private void ValidateDomain(string name)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Invalid name. Name is required!");

            DomainExceptionValidation.When(name.Length < 3, "Invalid name, too short, minimum 3 characters!");

            Name = name;
        }
    }
}
