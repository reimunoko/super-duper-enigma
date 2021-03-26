using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeService.UI.Model
{
    [System.AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    public class AcmeGridColumnAttribute:Attribute
    {
        public AcmeGridColumnAttribute(string name)
        {
            Name = name;
        }

        public string Name { get; }
    }
}
