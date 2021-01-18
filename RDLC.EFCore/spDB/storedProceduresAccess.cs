using RDLC.EFCore.Models.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
//using Dominio;

namespace RDLC.EFCore.spDB
{
    public class storedProceduresAccess
    {
        private readonly BikeStoreContext dbContext;

        public storedProceduresAccess()
        {
            dbContext = new BikeStoreContext();
        }

        public List<Customer> getCustomersList() => dbContext.Customers.ToList();

        public List<Customer> getCustomersListNoTracking() => dbContext.Customers.AsNoTracking().ToList();

        public IList<Customer> getCustomersIList() => dbContext.Customers.ToList();

        public IList<Customer> getCustomersIListNoTracking() => dbContext.Customers.AsNoTracking().ToList();

        public IEnumerable<Customer> getCustomersIEnumerable() => dbContext.Customers.ToList();

        public IEnumerable<Customer> getCustomersIEnumerableNoTracking() => dbContext.Customers.AsNoTracking().ToList();

        public async Task<IEnumerable<Customer>> getAsyncCustomersIEnumerable() => await dbContext.Customers.ToListAsync();

        public async Task<IEnumerable<Customer>> getAsyncCustomersIEnumerableNoTracking() => await dbContext.Customers.AsNoTracking().ToListAsync();

        public IEnumerable<Customer> getCustomerFromSqlRaw()=> dbContext.Customers.FromSqlRaw("EXECUTE getCustomers").ToList();
        

    }
}
