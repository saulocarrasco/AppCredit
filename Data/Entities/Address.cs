using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities
{
    public class Address : IBaseObject
    {
        public string Street { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public int Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool IsDeleted { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DateTimeOffset CreationDate { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DateTimeOffset DeletedDate { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
