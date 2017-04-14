using System;
using System.Collections.Generic;

namespace DataAccess.Model
{
    public partial class CustomerDocument
    {
        public Guid FileId { get; set; }
        public string FileName { get; set; }
        public byte[] FileContent { get; set; }
        public string ContentType { get; set; }
        public int CustomerId { get; set; }
    }
}
