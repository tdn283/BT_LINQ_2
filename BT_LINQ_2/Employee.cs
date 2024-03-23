using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT_LINQ_2
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public decimal Salary { get; set; }
        public int PositionId { get; set; }
        public Employee(int id, string name, int age, int salary, int positionId)
        {
            Id = id;
            Name = name;
            Age = age;
            Salary = salary;
            PositionId = positionId;
        }
    }
}
