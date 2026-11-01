using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestingForEon.Database.Models;
using UnitTestingForEon.ServiceLayer;

namespace UnitTestingForEon.Database.Mappers
{
    public class VendorMapper
    {
        private LoggingService<VendorMapper> logger;
        public VendorMapper(LoggingService<VendorMapper> logger)
        {
            this.logger = logger;
        }
        public Vendor MapVendor(SqlDataReader? reader)
        {
            logger.LogInformation("Mapping vendor from data reader.");
            try
            {
                return new Vendor
                (
                    BusinessEntityId: reader.GetInt32(reader.GetOrdinal("BusinessEntityID")),
                    AccountNumber: reader.GetString(reader.GetOrdinal("AccountNumber")),
                    Name: reader.GetString(reader.GetOrdinal("Name")),
                    CreditRating: reader.GetByte(reader.GetOrdinal("CreditRating")),
                    PreferredVendorStatus: reader.GetBoolean(reader.GetOrdinal("PreferredVendorStatus")),
                    ActiveFlag: reader.GetBoolean(reader.GetOrdinal("ActiveFlag")),
                    PurchasingWebServiceUrl: reader.IsDBNull(reader.GetOrdinal("PurchasingWebServiceURL"))
                        ? null
                        : reader.GetString(reader.GetOrdinal("PurchasingWebServiceURL")),
                    ModifiedDate: reader.GetDateTime(reader.GetOrdinal("ModifiedDate"))
                );
            }
            catch(Exception ex)
            {
                logger.LogError(ex, "Induced Failure for testing");
                return new Vendor(0,string.Empty, string.Empty,0,false,false, string.Empty,DateTime.Now);
            }
        }
    }
}