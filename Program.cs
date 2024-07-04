using EmployeeFormsApp;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace EmployeeFormsApp
{
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]

        static void Main()
        {

            using (var context = new DbConnect())
            {
                if (!context.Employees.Any())
                {
                    var bra1 = new Branch()
                    {
                        Name = "Центральный аппарат",
                        Location = "Россия, Москва, Походный пр., д. 3, стр.1"
                    };

                    var bra2 = new Branch()
                    {
                        Name = "Офис на Звонарском переулке",
                        Location = "Россия, Москва, Звонарский пер., д.7 стр. 2"
                    };

                    var bra3 = new Branch()
                    {
                        Name = "Филиал в Чувашской Республике",
                        Location = "Россия, Чебоксары, Московский проспект, д. 38, корп. 4"
                    };
                    var dep1 = new Department()
                    {
                        Name = "Отдел разработчиков",
                        Head = "Иванов Илья Иванович"
                    };
                    var dep2 = new Department()
                    {
                        Name = "Отдел аналитиков",
                        Head = "Иванова Эльвира Витальевна"
                    };
                    var dep3 = new Department()
                    {
                        Name = "Отдел тестировщиков",
                        Head = "Петрова Екатерина Ивановна"
                    };
                    var pos1 = new Position()
                    {
                        Name = "Разработчик",
                        Salary = 150000
                    };
                    var pos2 = new Position()
                    {
                        Name = "Тестировщик",
                        Salary = 100000
                    };
                    var pos3 = new Position()
                    {
                        Name = "Аналитик",
                        Salary = 100000
                    };
                    var pos4 = new Position()
                    {
                        Name = "Главный разработчик",
                        Salary = 300000
                    };
                    var pos5 = new Position()
                    {
                        Name = "Главный тестировщик",
                        Salary = 170000
                    };
                    var pos6 = new Position()
                    {
                        Name = "Главный аналитик",
                        Salary = 200000
                    };

                    var employee = new Employee()
                    {
                        Name = "Иванов",
                        Surname = "Илья",
                        Patronymic = "Иванович",
                        Gender = "M",
                        BirthDate = new DateTime(2000, 05, 12),
                        Address = "п.Иваново, 10",
                        PhoneNumber = "89603131271",
                        Email = "ivanov@gmail.com",
                        HireDate = new DateTime(2020, 06, 21),
                        INN = "1231213111",
                        PassportSeries = "9712",
                        PassportNumber = "323113",
                        PassportIssueBy = "МВД",
                        PassportIssueDate = new DateTime(2020, 06, 06),
                        PlaceOfReg = "Мира",
                        PhotoPath = "C:\\Users\\Александр\\EmployeeFormsApp\\Photo\\Dog.jpg",
                        Branch = bra3,
                        Department = dep1
                    };
                    var employee2 = new Employee()
                    {
                        Name = "Иванов",
                        Surname = "Дмитрий",
                        Patronymic = "Иванович",
                        Gender = "M",
                        BirthDate = new DateTime(1985, 05, 12),
                        Address = "Пр.Тракторостроителей",
                        PhoneNumber = "89613131271",
                        Email = "ivanov123@gmail.com",
                        HireDate = new DateTime(2012, 12, 12),
                        INN = "1131213111",
                        PassportSeries = "9731",
                        PassportNumber = "323443",
                        PassportIssueBy = "МВД",
                        PassportIssueDate = new DateTime(2010, 07, 06),
                        PlaceOfReg = "Яковлева",
                        PhotoPath = "C:\\Users\\Александр\\source\\EmployeeFormsApp\\Photo\\Dog1.jpg",
                        Branch = bra3,
                        Department = dep2
                    };
                    var employee3 = new Employee()
                    {
                        Name = "Иванова",
                        Surname = "Эльвира",
                        Patronymic = "Витальевна",
                        Gender = "Ж",
                        BirthDate = new DateTime(1980, 05, 12),
                        Address = "Пр.Мира",
                        PhoneNumber = "89173131271",
                        Email = "elvira123@gmail.com",
                        HireDate = new DateTime(2005, 12, 12),
                        INN = "1231113111",
                        PassportSeries = "9700",
                        PassportNumber = "323000",
                        PassportIssueBy = "МВД",
                        PassportIssueDate = new DateTime(2004, 07, 06),
                        PlaceOfReg = "Яковлева",
                        PhotoPath = "C:\\Users\\Александр\\source\\EmployeeFormsApp\\Photo\\Dog2.jpg",
                        Branch = bra3,
                        Department = dep2
                    };
                    var employee4 = new Employee()
                    {
                        Name = "Петрова",
                        Surname = "Екатерина",
                        Patronymic = "Ивановна",
                        Gender = "Ж",
                        BirthDate = new DateTime(1992, 05, 12),
                        Address = "п.Кугеси, 1",
                        PhoneNumber = "89173131279",
                        Email = "petrova123@gmail.com",
                        HireDate = new DateTime(2014, 12, 12),
                        INN = "1231213119",
                        PassportSeries = "9793",
                        PassportNumber = "323421",
                        PassportIssueBy = "МВД",
                        PassportIssueDate = new DateTime(2009, 07, 06),
                        PlaceOfReg = "Яковлева",
                        PhotoPath = "C:\\Users\\Александр\\source\\EmployeeFormsApp\\Photo",
                        Branch = bra3,
                        Department = dep3
                    };
                    var posInfo1 = new PositionInfo()
                    {
                        Date = new DateTime(2020, 06, 21),
                        Position = pos1,
                        Employee = employee
                    };
                    var posInfo2 = new PositionInfo()
                    {
                        Date = new DateTime(2024, 06, 21),
                        Position = pos4,
                        Employee = employee
                    };
                    var posInfo3 = new PositionInfo()
                    {
                        Date = new DateTime(2014, 12, 12),
                        Position = pos2,
                        Employee = employee4
                    };
                    var posInfo4 = new PositionInfo()
                    {
                        Date = new DateTime(2021, 06, 21),
                        Position = pos5,
                        Employee = employee4
                    };
                    var posInfo5 = new PositionInfo()
                    {
                        Date = new DateTime(2005, 12, 12),
                        Position = pos3,
                        Employee = employee3
                    };
                    var posInfo6 = new PositionInfo()
                    {
                        Date = new DateTime(2015, 06, 21),
                        Position = pos6,
                        Employee = employee3
                    };
                    var posInfo7 = new PositionInfo()
                    {
                        Date = new DateTime(2012, 12, 12),
                        Position = pos1,
                        Employee = employee2
                    };
                    var education = new Education()
                    {
                        EducationLevel = "Бакалавр",
                        Specialization = "Программное обеспечение",
                        Institution = "ЧГУ",
                        DateGrade = new DateTime(2005, 12, 12),
                        Employee = employee2
                    };
                    var education2 = new Education()
                    {
                        EducationLevel = "Среднее профессиональное",
                        Specialization = "Право",
                        Institution = "Кооперативный техникум",
                        DateGrade = new DateTime(2013, 12, 12),
                        Employee = employee4
                    };
                    var education3 = new Education()
                    {
                        EducationLevel = "Магистр",
                        Specialization = "Искусственный интеллект",
                        Institution = "ВШЭ",
                        DateGrade = new DateTime(2020, 12, 12),
                        Employee = employee
                    };
                    var education4 = new Education()
                    {
                        EducationLevel = "Бакалавр",
                        Specialization = "Дизайн",
                        Institution = "ЧГУ",
                        DateGrade = new DateTime(2005, 6, 12),
                        Employee = employee3
                    };
                    context.Branches.Add(bra1);
                    context.Branches.Add(bra2);
                    context.Branches.Add(bra3);
                    context.Departments.Add(dep1);
                    context.Departments.Add(dep2);
                    context.Departments.Add(dep3);
                    context.Positions.Add(pos1);
                    context.Positions.Add(pos2);
                    context.Positions.Add(pos3);
                    context.Positions.Add(pos4);
                    context.Positions.Add(pos5);
                    context.Positions.Add(pos6);
                    context.Employees.Add(employee);
                    context.Employees.Add(employee2);
                    context.Employees.Add(employee3);
                    context.Employees.Add(employee4);
                    context.Educations.Add(education);
                    context.Educations.Add(education2);
                    context.Educations.Add(education3);
                    context.Educations.Add(education4);
                    context.PositionInfos.Add(posInfo1);
                    context.PositionInfos.Add(posInfo2);
                    context.PositionInfos.Add(posInfo3);
                    context.PositionInfos.Add(posInfo4);
                    context.PositionInfos.Add(posInfo5);
                    context.PositionInfos.Add(posInfo6);
                    context.PositionInfos.Add(posInfo7);
                    context.SaveChanges();


                }
            }

            string connectionString = "Host=localhost;Database=employees;Username=postgres;Password=admin";
            string createFunctionGetEmployees = @"
                CREATE OR REPLACE FUNCTION GetEmployees()
                RETURNS TABLE (Id INTEGER, Name TEXT, Surname TEXT, Patronymic TEXT,
                    HireDate TIMESTAMP)
                LANGUAGE plpgsql
                AS $$
                BEGIN
                    RETURN QUERY SELECT e.""Id"",e.""Name"", e.""Surname"" , e.""Patronymic"" , e.""HireDate"" FROM employees as e;
                END;
                $$;
            ";
            string createProcedureAddEmployee = @"
                CREATE OR REPLACE PROCEDURE AddEmployee(
                IN pname TEXT,
                IN psurname TEXT,
                IN ppatronymic TEXT,
                IN phiredate TIMESTAMP
                )
                LANGUAGE plpgsql
                AS $$
                BEGIN
                    INSERT INTO employees (""Name"", ""Surname"", ""Patronymic"", ""HireDate"")
                    VALUES (pname, psurname, ppatronymic, phiredate);
                END;
                $$;
            ";
            string createProcedureDeleteEmployees = @"
                CREATE OR REPLACE PROCEDURE DeleteEmployeesByIds(IN ids integer[])
                LANGUAGE plpgsql
                AS $$
                BEGIN
                    DELETE FROM employees WHERE employees.""Id"" = ANY(ids);
                END;
                $$;
            ";
            string createFunctionSearchEmployee = @"
                CREATE OR REPLACE FUNCTION SearchEmployee(search TEXT)
                    RETURNS TABLE (Id INTEGER, Name TEXT, Surname TEXT, Patronymic TEXT,
                    HireDate TIMESTAMP)
                    AS $$
                    BEGIN
                        RETURN QUERY
                        SELECT e.""Id"",e.""Name"", e.""Surname"", e.""Patronymic"", e.""HireDate""
                        FROM employees as e
                        WHERE e.""Name"" ILIKE '%' || search || '%' OR e.""Surname"" ILIKE '%' || search || '%' OR e.""Patronymic"" ILIKE '%' || search || '%';
                    END;
                    $$ LANGUAGE plpgsql;
            ";


            string createProcedureGetInfoEmployee = @"
            CREATE OR REPLACE PROCEDURE GetInfoEmployee(
                IN empId INTEGER
            )
            LANGUAGE plpgsql
            AS $$
            BEGIN
                SELECT e.Name, e.Surname, e.Patronymic, e.Gender, e.BirthDate, e.INN, e.SNILS, e.Phone, e.Email,
                       e.HireDate, b.Name AS BranchName, d.Name AS DepartmentName, d.Head, p.Name AS PositionName,
                       p.Salary, e.PassportSeries, e.PassportNumber, e.PassportIssueDate, e.PassportIssueBy,
                       e.PlaceOfReg, e.Address, s.EducationLevel, s.Specialization, s.Institution, s.DateGrade
                FROM Employees e
                LEFT JOIN Branches b ON e.BranchId = b.Id
                LEFT JOIN Departments d ON e.DepartmentId = d.Id
                LEFT JOIN PositionInfos i ON e.Id = i.EmployeeId
                LEFT JOIN Positions p ON i.PositionId = p.Id
                LEFT JOIN Educations s ON e.Id = s.EmployeeId
                WHERE e.Id = empId;
            END;
            $$;

            ";

            /*string createProcedureChangeBasicInfo = @"
            CREATE PROCEDURE ChangeBasicInfoEmployee
                AS
                BEGIN
                    UPDATE Employees SET Name = @name, Surname = @surname, Patronymic = @patronymic, Gender = @gender, Birthdate = @birthDate,
                        Address = @address, Position = @position, INN = @INN, SNILS = @SNILS, PhoneNumber = @phone, Email = @email,
                        Hiredate = @hireDate WHERE Id = @id;
                END
                
            ";*/

            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                NpgsqlCommand command = new NpgsqlCommand(createFunctionGetEmployees, connection);
                command.ExecuteNonQuery();
                command = new NpgsqlCommand(createProcedureGetInfoEmployee, connection);
                command.ExecuteNonQuery();
                command = new NpgsqlCommand(createProcedureAddEmployee, connection);
                command.ExecuteNonQuery();
                command = new NpgsqlCommand(createProcedureDeleteEmployees, connection);
                command.ExecuteNonQuery();
                command = new NpgsqlCommand(createFunctionSearchEmployee, connection);
                command.ExecuteNonQuery();
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
