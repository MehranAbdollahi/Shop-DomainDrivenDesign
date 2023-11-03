using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop.Application.Categories.DTOs;
using Shop.Domain.CategoryAgg;

namespace Shop.Application.Categories.Mappers
{
    internal class CategoryMapper
    {
        public static CategoryDto Map(Category category)
        {
            return new CategoryDto()
            {
                Id = category.Id,
                Title = category.Title,
                ParentId = category.ParentId
            };
        }
    }
}
