using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace EmployeeFormsApp
{
    
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Имя обязательно для заполнения")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Имя не должно быть меньше 2 символов и больше 50 символов")]
        [RegularExpression(@"^[А-Яа-яЁёA-Za-z\s]+$", ErrorMessage = "Имя должно содержать только буквы")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Фамилия обязательна для заполнения")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Фамилия не должна быть меньше 2 символов и больше 50 символов")]
        [RegularExpression(@"^[А-Яа-яЁёA-Za-z\s]+$", ErrorMessage = "Фамилия должна содержать только буквы")]
        public string Surname { get; set; }
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Отчество не должно быть меньше 2 символов и больше 50 символов")]
        [RegularExpression(@"^[А-Яа-яЁёA-Za-z\s]*$", ErrorMessage = "Отчество должно содержать только буквы")]
        public string Patronymic { get; set; }
        public string Gender { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Address { get; set; }
        [RegularExpression(@"^\+?\d{1,4}?[-.\s]?\(?\d{1,3}?\)?[-.\s]?\d{1,4}[-.\s]?\d{1,4}[-.\s]?\d{1,9}$", ErrorMessage = "Некорректный номер телефона")]
        public string PhoneNumber { get; set; }
        [EmailAddress(ErrorMessage = "Некорректный email адрес")]
        public string Email { get; set; }
        public DateTime HireDate { get; set; }
        [RegularExpression(@"^\d{12}$", ErrorMessage = "ИНН должен содержать 12 цифр")]
        public string INN { get; set; }
        [RegularExpression(@"^\d{11}$", ErrorMessage = "СНИЛС должен содержать 11 цифр")]
        public string SNILS { get; set; }
        [RegularExpression(@"^\d{4}$", ErrorMessage = "Серия паспорта должна содержать 4 цифры")]
        public string PassportSeries { get; set; }
        [RegularExpression(@"^\d{6}$", ErrorMessage = "Номер паспорта должен содержать 6 цифр")]
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
