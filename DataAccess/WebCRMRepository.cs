using DataAccess.Model;
using System;


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
            return _dbContext;
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
