﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurchaseManagament.Application.Concrete.Models.RequestModels.Employee
{
    public class LoginVM
    {
        public string UsernameOrEmail { get; set; }
        public string Password { get; set; }
    }
}
