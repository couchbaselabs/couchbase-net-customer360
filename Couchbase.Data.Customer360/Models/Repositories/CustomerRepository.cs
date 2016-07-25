using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Couchbase;
using Couchbase.Core;
using Couchbase.Data.DAL;
using Couchbase.N1QL;
using Couchbase.Views;

namespace Couchbase.Data.Customer360.Models.Repositories
{
    public class CustomerRepository : Repository<Customer>
    {
        public CustomerRepository(IBucket bucket)
            : base(bucket)
        {
        }

        public IEnumerable<Customer> SelectAllCustomers(int index, int limit)
        {
            const string statement = "SELECT * FROM `customer360` " +
                                     "LIMIT $1 " +
                                     "OFFSET $2;";

            return Select(new QueryRequest(statement)
                .AddPositionalParameter(index)
                .AddPositionalParameter(limit));
        }
    }
}