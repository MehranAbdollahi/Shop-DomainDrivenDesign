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
        private Category category = new Category("title", 1);

        public CategoryTests()
        {

        }

        [Fact]
        public void Should_Create_Category()
        {



            category.Title.Should().Be("title");
            category.ParentId.Should().Be(1);
            category.Id.Should().Be(category.Id);
        }

        [Fact]
        public void Edit_Should_update_exist_category()
        {

            category.Edit("new title", 2);


            category.ParentId.Should().Be(2);
        }

        [Fact]
        public void RemoveItem_Should_throw_NullOrEmptyDomainDataException_when_order_item_not_found()
        {
            category.AddItem(2);

            var res = () => category.RemoveItem(1);

            res.Should().ThrowExactly<NullOrEmptyDomainDataException>();
        }

        [Fact]
        public void RemoveItem_Should_remove_exist_category()
        {
            category.AddItem(0);

            category.RemoveItem(0);

            category.TotalCategoryItems.Should().Be(0);

        }

    }
}
