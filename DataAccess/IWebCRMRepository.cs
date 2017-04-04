using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public interface IWebCRMRepository
    {
        dynamic GetCustomers();

        dynamic GetCustomer(int id);

        dynamic GetCustomerContacts(int customerId);

        dynamic GetContact(int contactId);

        dynamic GetIndustryTypes();

    }
}
