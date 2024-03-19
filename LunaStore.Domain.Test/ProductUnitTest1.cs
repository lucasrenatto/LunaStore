using FluentAssertions;
using LunaStore.Domain.Entities;

namespace LunaStore.Domain.Test
{
    public class ProductUnitTest1
    {
        [Fact]
        public void CreateProduct_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new ProductEntity(1, "Product Name", "Product Description", 9.99m,
                99, "product image");
            action.Should()
                .NotThrow<Validation.DomainExceptionValidation>();
        }

        [Fact]
        public void CreateProduct_NegativeIdValue_DomainExceptionInvalidId()
        {
            Action action = () => new ProductEntity(-1, "Product Name", "Product Description", 9.99m,
                99, "product image");

            action.Should().Throw<Validation.DomainExceptionValidation>()
                .WithMessage("Invalid Id value");
        }

        [Fact]
        public void CreateProduct_ShortNameValue_DomainExceptionShortName()
        {
            Action action = () => new ProductEntity(1, "Pr", "Product Description", 9.99m, 99,
                "product image");
            action.Should().Throw<Validation.DomainExceptionValidation>()
                 .WithMessage("Invalid name, too short, minimum 3 characters!");
        }

        [Fact]
        public void CreateProduct_LongImageName_DomainExceptionLongImageName()
        {
            Action action = () => new ProductEntity(1, "Product Name", "Product Description", 9.99m,
                99, "product image toooooooooooooooooooooooooooooooooooooooooooo loooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooogggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggg");

            action.Should()
                .Throw<Validation.DomainExceptionValidation>()
                 .WithMessage("Invalid image name, too long, maximum 250 characters!");
        }

        [Fact]
        public void CreateProduct_WithNullImageName_NoDomainException()
        {
            Action action = () => new ProductEntity(1, "Product Name", "Product Description", 9.99m, 99, null);
            action.Should().NotThrow<Validation.DomainExceptionValidation>();
        }

        [Fact]
        public void CreateProduct_WithEmptyImageName_NoDomainException()
        {
            Action action = () => new ProductEntity(1, "Product Name", "Product Description", 9.99m, 99, "");
            action.Should().NotThrow<Validation.DomainExceptionValidation>();
        }

        [Fact]
        public void CreateProduct_InvalidPriceValue_DomainException()
        {
            Action action = () => new ProductEntity(1, "Product Name", "Product Description", -9.99m,
                99, "");
            action.Should().Throw<Validation.DomainExceptionValidation>()
                 .WithMessage("Invalid price value!");
        }

        [Theory] // Eu uso Theory para indicar que o teste vai receber parametros
        [InlineData(-5)] // Uso InlineData para representar esses parametros em sequencia
        public void CreateProduct_InvalidStockValue_ExceptionDomainNegativeValue(int value)
        {
            Action action = () => new ProductEntity(1, "Pro", "Product Description", 9.99m, value,
                "product image");
            action.Should().Throw<Validation.DomainExceptionValidation>()
                   .WithMessage("Invalid stock value!");
        }
    }
}
