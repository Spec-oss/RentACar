using LinqToDB;
using LinqToDB.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.Linq2db
{
    public class Linq2dbSettings : ILinqToDBSettings
    {
        public IEnumerable<IDataProviderSettings> DataProviders
            => Enumerable.Empty<IDataProviderSettings>();

        public string DefaultConfiguration => "SqlServer";
        public string DefaultDataProvider => "SqlServer";

        public IEnumerable<IConnectionStringSettings> ConnectionStrings
        {
            get
            {
                yield return
                    new ConnectionStringSettings
                    {
                        Name = "RentACar",
                        ProviderName = ProviderName.SqlServer,
                        ConnectionString =
                            @"Server=DESKTOP-EOISGJ5;Database=RentACar;Trusted_Connection=true"
                    };
            }
        }
    }
}
