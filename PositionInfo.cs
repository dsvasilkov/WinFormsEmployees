using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeFormsApp
{
    public class PositionInfo
    {
        [Key]
        public int Id { get; set; } 
        public DateTime Date { get; set; }
        public virtual Employee Employee { get; set; }
        public int EmployeeId { get; set; }
        public int PositionId { get; set; }

        public virtual Position Position { get; set; }

    }
}
