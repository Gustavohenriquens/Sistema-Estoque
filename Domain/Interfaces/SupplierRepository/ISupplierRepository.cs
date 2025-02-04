using Domain.Models.Suppliers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.SupplierRepository
{
    public interface ISupplierRepository : IGenericRepository<Supplier>
    {
    }
}
