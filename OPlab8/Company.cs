using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace OPlab8
{
    public class Company
    {
        public List<Employee> employees = new List<Employee>();
        public List<Project> projects = new List<Project>();
        public List<Position> positions = new List<Position>();
        public List<Unit> units = new List<Unit>();

        public Employee AddEmployee(string Name, string Surname)
        {
            var employee = new Employee(Name,Surname);
            employees.Add(employee);
            return employee;
        }

        public void RemoveEmployee(Employee employee)
        {
            employees.Remove(employee);
        }

        public void SortEmployeesByName() => employees.Sort((a, b) => a.name.CompareTo(b.name));

        public void SortEmployeesBySurname() => employees.Sort((a, b) => a.surname.CompareTo(b.surname));

        public void SortEmployeesBySalary() => employees.Sort((a, b) => a.position.salary.CompareTo(b.position.salary));

        public Unit AddUnit()
        {
            var unit = new Unit();
            units.Add(unit);
            return unit;
        }

        public void SortUnitsByPrice() => units.Sort((a, b) => a.GetProjectsPrice().CompareTo(b.GetProjectsPrice()));

        public Position[] FindBestPositions()
        {
            positions.Sort((a, b) => (a.salary / a.workHours).CompareTo(b.salary / b.workHours));
            positions.Reverse();
            var result = new Position[5];
            for (int i = 0; i < Math.Min( result.Length, positions.Count); i++)
            {
                result[i] = positions[i];
            }
            return result;
        }

        public List<Employee> FindByWordInEmployees(string word)
        {
            var result = new List<Employee>();
            foreach (var empl in employees) 
            {
                if(empl.name == word || empl.surname == word)
                    result.Add(empl);
            }
            return result;
        }

        public List<Employee> FindInEmployees(string name = null, string surname = null,
                                              int index = 0, int experiance = 0, Position position = null)
        {
            return employees.FindAll(s =>
            (name == null || s.name.Equals(name))
            && (surname == null || s.surname.Equals(surname))
            && (index == 0 || s.index.Equals(index))
            && (position == null || s.position.Equals(position))
            && (experiance == 0 || s.experience.Equals(experiance)));
        }

        public List<Project> FindByWordInProjects(string word)
        {
            var result = new List<Project>();
            foreach (var proj in projects)
            {
                if (proj.ProjectName == word)
                    result.Add(proj);
            }
            return result;
        }

        public List<Object> FindByWord(string word)
        {
            var result = new List<Object>();
            result.AddRange(FindByWordInEmployees(word));
            result.AddRange(FindByWordInProjects(word));
            foreach (var pos in positions)
            {
                if(word == pos.name)
                    result.Add(pos);
            }
            foreach (var unit in units)
            {
                if(unit.Name == word)
                    result.Add(unit);
            }
            return result;
        }
    }
}
