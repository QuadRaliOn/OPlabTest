using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPlab8
{
    public class Position
    {
        public string name { get; set; }
        List<Employee> employees = new List<Employee>();
        public int workHours { get; set; }

        public int salary { get; set; }

        public float GetProfitability => salary / (float)workHours;

        public void AddEmployee(Employee employee) => employees.Add(employee);

        public void RemoveEmployee(Employee employee) => employees.Remove(employee);

        public Employee FindBest()
        {
            Employee best = employees[0];
            float bestIndex = best.GetProjectsPrice() / (float)best.experience;
            foreach (Employee emp in employees)
            {
                if((float)emp.GetProjectsPrice()/emp.experience > bestIndex)
                {
                    bestIndex = (float)emp.GetProjectsPrice() / emp.experience;
                    best = emp;
                }
            }
            return best;
        }
    }
}
