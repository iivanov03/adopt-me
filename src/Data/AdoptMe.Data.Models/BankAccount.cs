using AdoptMe.Data.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdoptMe.Data.Models
{
    public class BankAccount : BaseDeletableModel<int>
    {
        public string VetClinic { get; set; }

        public string Address { get; set; }

        public string BankAccountNumber { get; set; }
    }
}
