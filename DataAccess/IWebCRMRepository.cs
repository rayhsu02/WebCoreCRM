﻿using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public interface IWebCRMRepository
    {
        dynamic GetCustomers();

        dynamic GetCustomer(int id);

        dynamic SaveCustomer(Customer customer);

        dynamic UpdateCustomer(Customer customer);

        dynamic DeleteCustomer(int id);

        dynamic GetCustomerContacts(int customerId);

        dynamic SaveContact(CustomerContacts contact);

        dynamic UpdateContact(CustomerContacts contact);

        void SetPrimaryContact(int customerId, int contactId);

        dynamic DeleteContact(int id);

        dynamic GetContact(int contactId);

        dynamic GetIndustryTypes();

       

    }
}
