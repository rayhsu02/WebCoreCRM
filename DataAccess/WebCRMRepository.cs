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

        public dynamic DeleteCustomer(int id)
        {
            var customer = _dbContext.Customer.SingleOrDefault(m => m.CustomerId == id);
            if (customer == null)
            {
                return 0;
            }

            _dbContext.Customer.Remove(customer);
            return _dbContext.SaveChangesAsync();
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
           return _dbContext.SaveChangesAsync();
          
        }

        public dynamic UpdateCustomer(Customer customer)
        {
            _dbContext.Entry(customer).State = EntityState.Modified;

            try
            {
                return _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GetCustomer(customer.CustomerId))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }
        }
    }
}
