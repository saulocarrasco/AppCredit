﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities
{
    public abstract class Person
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTimeOffset BirthDate { get; set; }
        public string MobilePhone { get; set; }
        public string PhoneNumber { get; set; }
        public IEnumerable<Address> Addresses { get; set; }
        public IEnumerable<Identification> Identifications { get; set; }
        public IEnumerable<Credit> Credits { get; set; }
    }
}