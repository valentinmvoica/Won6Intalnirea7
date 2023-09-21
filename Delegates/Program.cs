using System;
using System.Collections.Generic;
using System.Linq;

namespace Delegates
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    class EmpolyeeManagement
    {
        private List<Employee> employees = new List<Employee>();
        public void AddEmployee(Employee employeeToAdd)
        {
            if (employees.Exists(e => e.Id == employeeToAdd.Id))
            {
                throw new InvalidIdException("Duplicated employee detected!");
            }
            employees.Add(employeeToAdd);
        }
        public void RemoveEmployee(Guid employeeId)
        {
            if (!employees.Exists(e => e.Id == employeeId))
            {
                throw new InvalidIdException("Invalid employee id");
            }

            var employee = employees.Find(e => e.Id == employeeId);
            if (employee != null)
            {
                employees.Remove(employee);
            }
        }

        public List<Employee> GetNoOfWellPayedEmployees(double minimumSalary) =>
            employees.FindAll(e => e.Salary >= minimumSalary);

        public List<Employee> GetEmployeesByDepartment(Department department) =>
            employees.FindAll(e => e.Department == department);
        public List<Employee> GetMaxSalary()
        {
            double maxSalary = double.MinValue;
            employees.ForEach(e =>
                {
                    if (e.Salary > maxSalary)
                    {
                        maxSalary = e.Salary;
                    }
                });

            //  var max = employees.Max(e => e.Salary);

            return employees.FindAll(e => e.Salary == maxSalary);
        }
        public List<Employee> GetMaxSalary(Department department)
        {
            double maxSalary = double.MinValue;
            employees.ForEach(e =>
            {
                if (e.Salary > maxSalary && e.Department == department)
                {
                    maxSalary = e.Salary;
                }
            });

            //  var max = employees.Max(e => e.Salary);

            return employees.FindAll(e => e.Salary == maxSalary && e.Department == department);
        }
        public List<Employee> GetMaxSalary(List<Department> departments)
        {
            var employeesInSpecifiedDepartmensts = employees.FindAll(e => departments.Contains(e.Department));

            double maxSalary = double.MinValue;
            employeesInSpecifiedDepartmensts.ForEach(e =>
            {
                if (e.Salary > maxSalary)
                {
                    maxSalary = e.Salary;
                }
            });

            //  var max = employees.Max(e => e.Salary);

            return employeesInSpecifiedDepartmensts.FindAll(e => e.Salary == maxSalary );
        }
        public double GetTotalCost()
        {
            double cost = 0.0;
            employees.ForEach(e => cost += e.Salary);
            return cost;
        }
        public double GetTotalCost(Department department)
        {
            double cost = 0.0;

            employees.FindAll(e => e.Department == department).ForEach(e => cost += e.Salary);

            return cost;
        }
        public void IncreaseSalary(Guid employeeId, double percentage)
        {
            var employee = employees.Find(e => e.Id == employeeId);
            if (employee == null)
            {
                throw new InvalidIdException("Invalid employee id");
            }
            employee.Salary *= (100 + percentage);
        }
        public void IncreaseSalary(Department department, double percentage) =>
            employees.FindAll(e => e.Department == department).ForEach(e => e.Salary *= (100 + percentage));

        public void IncreaseSalary(List<Department> departments, double percentage) =>
             employees.FindAll(e => departments.Contains(e.Department)).ForEach(e => e.Salary *= (100 + percentage));

        public List<DepartmentSalary> GetMaxSalaryByDepartment(List<Department> departments)
        {
            var result = new List<DepartmentSalary>();
            departments.ForEach(department =>
            {
                var maxSalary = 0.0;
                employees.FindAll(e => e.Department == department).ForEach(e =>
                {
                    if (e.Salary > maxSalary)
                    {
                        maxSalary = e.Salary;
                    }
                });

                var richEmployees = employees.FindAll(e => e.Department == department && e.Salary == maxSalary);

                result.Add(new DepartmentSalary
                {
                    Dep = department,
                    Employees = richEmployees
                });
            }
            );

            return result;
        }

        /*
         * testare: 10000
         * dev 12000
         * hr 15000
         */

        }
    class DepartmentSalary
    {
        public Department Dep { get; set; }
        public List<Employee> Employees { get; set; }
    }

        class Employee
    {  
        public string Name { get; set; }
        public Guid Id { get; set; }
        public double Salary { get; set; }
        public Department Department { get; set; }
        public override string ToString() =>
            $"{Id}: {Name}  {Department}";

    }
    enum Department
    {
        Development,
        Testing,
        HumanResources,
        Maintenance,
        Logistics
    }
}
