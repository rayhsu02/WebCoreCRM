using System;
using System.Collections.Generic;

namespace DataAccess.Model
{
    public partial class CustomerContacts
    {
        public int CustomerContactId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public bool PrimaryContact { get; set; }
        public int CustomerId { get; set; }
    }
}
