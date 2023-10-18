using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.OrderAgg.Services
{
    public interface IOrderDomainService
    {
        bool IsProductNotExsist(long productId);
    }
}
