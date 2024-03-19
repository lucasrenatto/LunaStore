using FluentAssertions;
using LunaStore.Domain.Entities;

namespace LunaStore.Domain.Test
{
    public class CategoryUnitTest1
    {
        [Fact(DisplayName = "Create Category with Valid State")]
        public void CreateCategory_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new CategoryEntity(1, "Category name");
            action.Should().NotThrow<Validation.DomainExceptionValidation>();
        }
        [Fact]
        public void CreateCategory_NegativeIdValue_DomainExceptionInvalidId()
        {
            Action action = () => new CategoryEntity(-1, "Category Name ");
            action.Should()
                .Throw<Validation.DomainExceptionValidation>()
                 .WithMessage("Invalid Id value!");
        }

        [Fact]
        public void CreateCategory_ShortNameValue_DomainExceptionShortName()
        {
            Action action = () => new CategoryEntity(1, "Ca");
            action.Should()
                .Throw<Validation.DomainExceptionValidation>()
                   .WithMessage("Invalid name, too short, minimum 3 characters!");
        }

        [Fact]
        public void CreateCategory_MissingNameValue_DomainExceptionRequiredName()
        {
            Action action = () => new CategoryEntity(1, "");
            action.Should()
                .Throw<Validation.DomainExceptionValidation>()
                .WithMessage("Invalid name. Name is required!");
        }

        [Fact]
        public void CreateCategory_WithNullNameValue_DomainExceptionInvalidName()
        {
            Action action = () => new CategoryEntity(1, null);
            action.Should().Throw<Validation.DomainExceptionValidation>();
        }
    }
}