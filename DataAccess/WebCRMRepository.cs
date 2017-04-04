using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;


namespace DataAccess
{
    public class WebCRMRepository : IWebCRMRepository
    {
        private WebCRMDBContext _dbContext;

        public WebCRMRepository(WebCRMDBContext context)
        {
            _dbContext = context;
        }
        public dynamic GetCustomerContacts(int customerId)
        {
            return _dbContext.Customer.ToList();
        }

        public dynamic GetCustomers()
        {
            throw new NotImplementedException();
        }

        public dynamic GetIndustryTypes()
        {
            throw new NotImplementedException();
        }
    }
}
