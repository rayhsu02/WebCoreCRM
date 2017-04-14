using DataAccess.Model;
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

        dynamic SetPrimaryContact(CustomerContacts primaryContact);

        dynamic DeleteContact(int id);

        dynamic GetContact(int contactId);

        dynamic SaveCustomerDocument(CustomerDocument doc);

        dynamic GetCustomerDocuments(int customerId);

        dynamic UpdateCustomerDocument(CustomerDocument doc);

        dynamic DeleteCustomerDocument(string id);

        dynamic GetCustomerDocumentById(string docId);

        dynamic GetIndustryTypes();

       

    }
}
