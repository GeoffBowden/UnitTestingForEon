using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestingForEon.Database.Models
{
    // record introduced in c#9
    // record = data only, immutable, DTOs, API models 
    // equality comparison based on values
    // WinForms data binding generally works better with mutable properties, propertied with a setter are mutable
    public record Vendor
    (
        int BusinessEntityId,
        string AccountNumber,
        string Name,
        byte CreditRating,
        bool PreferredVendorStatus,
        bool ActiveFlag,
        string? PurchasingWebServiceUrl,
        DateTime ModifiedDate
    );
}
