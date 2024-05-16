using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace OPlab8
{
    public class Employee 
    {
        public string name { get; }
        public string surname { get; }
        public int index { get; set; }
        public int experience { get; set; }
        public Position position { get; set; }
        public List<Project> projects = new List<Project>();

        public Employee(string name, string surname)
        {
            this.name = name;  
            this.surname = surname;
        }    

        public void ChangePosition(Position position)
        {
            this.position.RemoveEmployee(this);
            this.position = position;
            position.AddEmployee(this);
        }

        public void AddProject(Project project)
        {
            projects.Add(project);
            project.AddEmployee(this);
        }

        public List<Project> GetProjects() => projects;

        public int GetProjectsPrice()
        {
            int price = 0;
            foreach (var item in projects)
            {
                price += item.GetPrice();
            }
            return price;
        }
    }
}
