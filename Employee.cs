using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace EmployeeFormsApp
{
    
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public string Gender { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public DateTime HireDate { get; set; }
        public string INN { get; set; }
        public string SNILS { get; set; }
        public string PassportSeries { get; set; }
        public string PassportNumber { get; set; }
        public DateTime? PassportIssueDate { get; set; }
        public string PassportIssueBy { get; set; }
        public string PlaceOfReg { get; set; }
        public string PhotoPath { get; set; }
        public int? BranchId { get; set; }
        public int? DepartmentId { get; set; }
        public virtual Branch Branch { get; set; }
        public virtual Department Department { get; set; }
        public ICollection <PositionInfo> PositionInfos { get; set; }
        public virtual Education Education { get; set; } 
    }
}
