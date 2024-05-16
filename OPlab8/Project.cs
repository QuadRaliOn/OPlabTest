using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPlab8
{
    public class Project
    {
        public string ProjectName { get; set; }
        public List<Employee> creators = new List<Employee>();
        
        public Project(string ProjectName, params Employee[] creators) 
        {
            this.ProjectName = ProjectName;
            this.creators = creators.ToList();
            foreach (Employee e in creators)
            {
                e.projects.Add(this);
            }
        }

        public void AddEmployee(Employee employee)
        {
            creators.Add(employee);
            employee.AddProject(this);
        }

        public int GetPrice()
        {
            int price = 0;
            foreach (var item in creators)
            {
                price += item.position.salary;
            }
            return price;
        }
    }
}
