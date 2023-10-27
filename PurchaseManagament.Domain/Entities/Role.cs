﻿using PurchaseManagament.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurchaseManagament.Domain.Entities
{
    public class Role:AuditableEntity
    {
        public string Name { get; set; }
        public IEnumerable<EmployeeRole> EmployeeRoles { get; set; }
    }
}
