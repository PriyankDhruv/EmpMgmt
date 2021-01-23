using System;
using System.Collections.Generic;

namespace EmpMgmt.DAO.Entites
{
    public partial class Employee
    {
        public long EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string Department { get; set; }
        public string MailId { get; set; }
        public DateTime? Doj { get; set; }
        public long? Phone { get; set; }
        public string Address { get; set; }
        public long? Salary { get; set; }
        public int? Age { get; set; }
    }
}
