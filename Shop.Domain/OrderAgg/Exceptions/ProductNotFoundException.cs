using Shop.Domain.Shared.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.OrderAgg.Exceptions
{
    public class ProductNotFoundException : BaseDomainException
    {
        public ProductNotFoundException() : base("Product Not Found")
        {

        }
    }
}
