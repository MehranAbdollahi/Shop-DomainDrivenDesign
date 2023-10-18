using Shop.Domain.Shared;
using Shop.Domain.Shared.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.ProductAgg
{
    public class ProductImage : BaseEntity
    {
        public ProductImage(long productId, string imageName)
        {
            NullOrEmptyDomainDataException.CheckString(imageName, "imageName");

            ProductId = productId;
            ImageName = imageName;
        }

        public long ProductId { get; private set; }
        public string ImageName { get; private set; }
    }
}
