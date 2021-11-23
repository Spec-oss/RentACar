using Core.Entity.Concrete;
using Entities.Concrete;
using LinqToDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.Linq2db
{
    public class RentACarContext : LinqToDB.Data.DataConnection
    {

        public RentACarContext(): base("RentACar") { }

        public ITable<Car> Cars { get; set; }
        public ITable<Color> Colors { get; set; }
        public ITable<Brand> Brands { get; set; }
        public ITable<Customer> Customers { get; set; }
        public ITable<Rental> Rentals { get; set; }
        public ITable<User> Users { get; set; }
        public ITable<UserOperationClaim> UserOperationClaims { get; set; }
        public ITable<OperationClaim> OperationClaims { get; set; }

    }
}
