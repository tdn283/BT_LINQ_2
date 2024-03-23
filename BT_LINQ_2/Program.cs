using BT_LINQ_2;
using System.Net.WebSockets;

List<Department> departments = new List<Department>()
{
    new Department(1, "Phong marketing"),
    new Department(2, "Phong IT"),
    new Department(3, "Phòng tai chinh"),
    new Department(4, "Phòng quan ly"),
    new Department(5, "Phòng nghien cuu")
};

List<Position> positions = new List<Position>()
{
    new Position(1, "Quan ly", 1),
    new Position(2, "Nhan vien", 1),
    new Position(3, "Quan ly", 2),
    new Position(4, "Nhan vien", 2),
    new Position(5, "Quan ly", 3),
    new Position(6, "Nhan vien", 3),
    new Position(7, "Quan ly", 4),
    new Position(8, "Nhan vien", 4),
    new Position(9, "Quan ly", 5),
    new Position(10, "Nhan vien", 5)
};

List<Employee> employees = new List<Employee>()
{
    new Employee(1, "Truong Dinh Nhat", 25, 3000, 1),
    new Employee(2, "Nguyen Duy Tung", 25, 2000, 2),
    new Employee(3, "To Ngoc Hai", 35, 3500, 3),
    new Employee(4, "Truong Thi Thuy Phuong", 40, 4000, 4),
    new Employee(5, "Nguyen Van Khanh", 22, 2200, 5),
    new Employee(6, "Pham Van Nhat Huy", 28, 2800, 1),
    new Employee(7, "Tran Nhu Anh Quan", 45, 4500, 2),
    new Employee(8, "Hoang Trong Quang Huy", 33, 3300, 3),
    new Employee(9, "Tran Phi Long", 38, 3800, 4),
    new Employee(10, "Le Van Hiep", 27, 2700, 5)
};

// tìm kiếm nhân viên theo tên, chức vụ hoặc phòng ban
Console.Write("Nhap tu khoa tim kiem: ");
string keyword = Console.ReadLine().ToLower();
var searchQuery = from employee in employees
                  join position in positions on employee.PositionId equals position.Id
                  join department in departments on position.DepartmentId equals department.Id
                  where employee.Name.ToLower().Contains(keyword) || position.Name.ToLower().Contains(keyword) || department.Name.ToLower().Contains(keyword)
                  select new
                  {
                      EmployeeName = employee.Name,
                      EmployeeAge = employee.Age,
                      EmployeeSalary = employee.Salary,
                      PositionName = position.Name,
                      DepartmentName = department.Name
                  };

foreach (var item in searchQuery)
{
    Console.WriteLine($"Employee: {item.EmployeeName}, Age: {item.EmployeeAge}, Salary: {item.EmployeeSalary}, Position: {item.PositionName}, Department: {item.DepartmentName}");
}

Console.WriteLine("-------------------------------------------------");

// tìm kiếm nhân viên theo tuổi tối thiểu
Console.Write("Nhap tuoi toi thieu: ");
int minAge = int.Parse(Console.ReadLine());
var searchByMinAge = from employee in employees
                     join position in positions on employee.PositionId equals position.Id
                     join department in departments on position.DepartmentId equals department.Id
                     where employee.Age >= minAge
                     select new
                     {
                         EmployeeName = employee.Name,
                         EmployeeAge = employee.Age,
                         EmployeeSalary = employee.Salary,
                         PositionName = position.Name,
                         DepartmentName = department.Name
                     };

foreach (var item in searchByMinAge)
{
    Console.WriteLine($"Employee: {item.EmployeeName}, Age: {item.EmployeeAge}, Salary: {item.EmployeeSalary}, Position: {item.PositionName}, Department: {item.DepartmentName}");
}

Console.WriteLine("-------------------------------------------------");

// tìm kiếm nhân viên theo tuổi tối đa
Console.Write("Nhap tuoi toi da: ");
int maxAge = int.Parse(Console.ReadLine());
var searchByMaxAge = from employee in employees
                     join position in positions on employee.PositionId equals position.Id
                     join department in departments on position.DepartmentId equals department.Id
                     where employee.Age <= maxAge
                     select new
                     {
                         EmployeeName = employee.Name,
                         EmployeeAge = employee.Age,
                         EmployeeSalary = employee.Salary,
                         PositionName = position.Name,
                         DepartmentName = department.Name
                     };

foreach (var item in searchByMaxAge)
{
    Console.WriteLine($"Employee: {item.EmployeeName}, Age: {item.EmployeeAge}, Salary: {item.EmployeeSalary}, Position: {item.PositionName}, Department: {item.DepartmentName}");
};

Console.WriteLine("-------------------------------------------------");

// tìm kiếm nhân viên theo vị trí
Console.Write("Nhap vi tri: ");
string positionName = Console.ReadLine().ToLower();
var searchByPosition = from employee in employees
                       join position in positions on employee.PositionId equals position.Id
                       join department in departments on position.DepartmentId equals department.Id
                       where position.Name.ToLower().Contains(positionName)
                       select new
                       {
                           EmployeeName = employee.Name,
                           EmployeeAge = employee.Age,
                           EmployeeSalary = employee.Salary,
                           PositionName = position.Name,
                           DepartmentName = department.Name
                       };

foreach (var item in searchByPosition)
{
    Console.WriteLine($"Employee: {item.EmployeeName}, Age: {item.EmployeeAge}, Salary: {item.EmployeeSalary}, Position: {item.PositionName}, Department: {item.DepartmentName}");
}

Console.WriteLine("-------------------------------------------------");

// tìm kiếm nhân viên theo phòng ban
Console.Write("Nhap phong ban: ");
string departmentName = Console.ReadLine().ToLower();
var searchByDepartment = from employee in employees
                         join position in positions on employee.PositionId equals position.Id
                         join department in departments on position.DepartmentId equals department.Id
                         where department.Name.ToLower().Contains(departmentName)
                         select new
                         {
                             EmployeeName = employee.Name,
                             EmployeeAge = employee.Age,
                             EmployeeSalary = employee.Salary,
                             PositionName = position.Name,
                             DepartmentName = department.Name
                         };

foreach (var item in searchByDepartment)
{
    Console.WriteLine($"Employee: {item.EmployeeName}, Age: {item.EmployeeAge}, Salary: {item.EmployeeSalary}, Position: {item.PositionName}, Department: {item.DepartmentName}");
}
