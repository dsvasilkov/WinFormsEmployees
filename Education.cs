using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeFormsApp
{
    public class Education

    {
        public int Id { get; set; }
        public string EducationLevel { get; set; }
        public string Specialization {  get; set; }
        public string Institution { get; set; }
        public DateTime DateGrade { get; set; }
        public int EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }  
    }
}
