using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities
{
    public interface IBaseObject
    {
        int Id { get; set; }
        bool IsDeleted { get; set; } 
        DateTimeOffset CreationDate { get; set; }
        DateTimeOffset DeletedDate { get; set; }
    }
}
