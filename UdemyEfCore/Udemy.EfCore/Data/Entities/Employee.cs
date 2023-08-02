using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UdemyEfCore.Data.Entities
{
   
    public class Employee
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

    }

    public class PartTimeEmployee : Employee
    {
        public decimal DailyWage { get; set; }
        public string Firstname { get; internal set; }
    }

    public class FullTimeEmployee : Employee
    {
        public decimal HourlyWage { get; set; }
    }
}
