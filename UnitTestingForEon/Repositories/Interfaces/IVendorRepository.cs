using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestingForEon.Database.Models;

namespace UnitTestingForEon.Repositories.Interfaces
{
    public interface IVendorRepository
    {
        IEnumerable<Vendor> GetAllAsync();

        Vendor? GetByIdAsync(int businessEntityId);

        int CreateAsync(Vendor vendor);

        bool UpdateAsync(Vendor vendor);

        bool DeleteAsync(int businessEntityId);
    }
}
