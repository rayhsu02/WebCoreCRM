using DataAccess.Model;
using Microsoft.EntityFrameworkCore;
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

        public dynamic GetContact(int contactId)
        {
            return _dbContext.CustomerContacts.SingleOrDefault(s => s.CustomerContactId == contactId);
        }

        public dynamic GetCustomer(int id)
        {
            return _dbContext.Customer.SingleOrDefaultAsync(c => c.CustomerId == id);
        }

        public dynamic GetCustomerContacts(int customerId)
        {
            return _dbContext.CustomerContacts.AsEnumerable();
        }

        public dynamic GetCustomers()
        {
            return _dbContext.Customer.AsEnumerable();
        }

        public dynamic GetIndustryTypes()
        {
            return _dbContext.IndustryType.AsEnumerable();
        }

        public dynamic SaveCustomer(Customer customer)
        {
            _dbContext.Entry(customer).State = EntityState.Added;
           return _dbContext.SaveChanges();
          
        }
    }
}
