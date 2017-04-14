using System;
using System.Collections.Generic;

namespace DataAccess.Model
{
    public partial class CustomerDocument
    {
        public int FilePathId { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public int CustomerId { get; set; }
    }
}
