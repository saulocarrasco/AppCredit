using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities
{
    public class Customer : Person, IBaseObject
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public DateTimeOffset CreationDate { get; set; }
        public DateTimeOffset DeletedDate { get; set; }
    }
}
