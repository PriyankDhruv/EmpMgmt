using System;
using System.Collections.Generic;

namespace EmpMgmt.DAO.Entites
{
    public partial class Employeemaster
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string ContactNo { get; set; }
        public string Address { get; set; }
        public int? IsApporved { get; set; }
        public int? Status { get; set; }
        public int? TotalCnt { get; set; }
    }
}