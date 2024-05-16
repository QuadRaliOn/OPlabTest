// Melnichuk Andrit V-4
using OPlab8;
using System.Runtime.InteropServices;

class Program
{
    static void Main()
    {
        var company = new Company();
        var Elon = company.AddEmployee("Elon", "Musk");
        Elon.experience = 10;
        Elon.index = 571093;
        var Fredy = company.AddEmployee("Fredy", "Cruger");
        Fredy.experience = 17;
        Fredy.index = 109123;
        var Anton = company.AddEmployee("Anton", "Vanish");
        var Ricka = company.AddEmployee("Ricka", "Tenero");
        Ricka.experience = 3;
        Ricka.index = 650134;
        company.RemoveEmployee(Anton);

        var manager = new Position();
        company.positions.Add(manager);
        manager.name = "Manager";
        manager.salary = 15000;
        manager.workHours = 8;
        var worker = new Position();
        company.positions.Add(worker);
        worker.name = "worker";
        worker.salary = 10000;
        worker.workHours = 8;

        Elon.position = manager;
        manager.AddEmployee(Elon);
        Fredy.position = worker;
        worker.AddEmployee(Fredy);
        Ricka.position = worker;
        worker.AddEmployee(Ricka);

        company.SortEmployeesByName();
        company.SortEmployeesBySurname();
        company.SortEmployeesBySalary();

        var Artists = new Unit();
        Artists.employees.Add(Ricka);
        Artists.employees.Add(Fredy);
        var Directors = new Unit();
        Directors.employees.Add(Elon);

        var firstProj = new Project("firstProject",Elon,Fredy);
        company.projects.Add(firstProj);
        var secondProj = new Project("secondProject", Elon, Ricka);
        company.projects.Add(secondProj);
        var lastproj = new Project("lastProject", Elon, Ricka,Fredy);
        company.projects.Add(lastproj);
        Artists.projects.Add(secondProj);
        Artists.projects.Add(secondProj);

        Directors.projects.Add(firstProj);
        Directors.projects.Add(secondProj);
        Directors.projects.Add(lastproj);

        var best = company.FindBestPositions();
        int price = Artists.GetProjectsPrice();
        var bestWorker = worker.FindBest();
        var findElon = company.FindByWordInEmployees("Elon");
        var findProj = company.FindByWordInProjects("secondProject");
        var findRicka = company.FindByWord("Tenero");
        var findPos = company.FindByWord("Manager");
        var findCruger = company.FindInEmployees(index: 109123);
        var findCruger2 = company.FindInEmployees(experiance: 17);
        var findCruger3 = company.FindInEmployees(name:"Fredy",surname:"Cruger",experiance: 17);
        return;
    }
}