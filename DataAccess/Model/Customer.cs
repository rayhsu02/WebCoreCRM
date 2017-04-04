using System;
using System.Collections.Generic;

namespace DataAccess.Model
{
    public partial class Customer
    {
        public int CustomerId { get; set; }
        public string CompanyName { get; set; }
        public string WebsiteUrl { get; set; }
        public int IndustryTypeId { get; set; }
        public bool ClientDesignation { get; set; }
    }
}
