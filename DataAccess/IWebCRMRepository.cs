using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public interface IWebCRMRepository
    {
        dynamic GetCustomers();

        dynamic GetCustomerContacts(int customerId);

        dynamic GetIndustryTypes();

    }
}
