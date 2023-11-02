using Shop.Domain.Shared.Exceptions;
using FluentAssertions;
using Xunit;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using Shop.Domain.CategoryAgg;
using Shop.Domain.Orders;
using Newtonsoft.Json.Linq;

namespace Shop.Domain.Test.Unit.CategoryAgg
{
    public class CategoryTests
    {
        private readonly Category _category = new Category("title", 1);

        public CategoryTests()
        {

        }

        [Fact]
        public void Should_Create_Category()
        {



            _category.Title.Should().Be("title");
            _category.ParentId.Should().Be(1);
            _category.Id.Should().Be(_category.Id);
        }

        [Fact]
        public void Edit_Should_update_exist_category()
        {

            _category.Edit("new title", 2);


            _category.ParentId.Should().Be(2);
        }

        [Fact]
        public void RemoveItem_Should_throw_NullOrEmptyDomainDataException_when_order_item_not_found()
        {
            _category.AddItem(2);

            var res = () => _category.RemoveItem(1);

            res.Should().ThrowExactly<NullOrEmptyDomainDataException>();
        }

        [Fact]
        public void RemoveItem_Should_remove_exist_category()
        {
            _category.AddItem(0);

            _category.RemoveItem(0);

            _category.TotalCategoryItems.Should().Be(0);

        }

    }
}
