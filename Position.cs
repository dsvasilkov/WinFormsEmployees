using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeFormsApp
{
    public class Position
    {
        [Key]
        public int  Id { get; set; }
     
        public string Name { get; set; }

        public int Salary { get; set; }
        public ICollection <PositionInfo> PositionInfos { get; set; }

    }
}
