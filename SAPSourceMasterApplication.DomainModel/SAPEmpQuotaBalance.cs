using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAPSourceMasterApplication.DomainModel
{
    public class SAPEmpQuotaBalance
    {
        [Key]
        public int SAPEmpQuotaBalanceID { get; set; }
        public int EmployeeID { get; set; }
        public decimal SickBalance { get; set; }
        public decimal VacBalance { get; set; }
        public decimal PerLeaveBalance { get; set; }
    }
}