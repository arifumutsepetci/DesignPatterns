using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visitor
{
    class Program
    {
        static void Main(string[] args)
        {
            Manager umut = new Manager {Name = "Umut", Salary = 1100};
            Manager arif = new Manager { Name="Arif",Salary = 800};

            Worker ahmet = new Worker {Name = "Ahmet", Salary = 600};
            Worker mehmet = new Worker { Name = "Mehmet", Salary = 600 };

            umut.Subordinates.Add(arif);
            arif.Subordinates.Add(ahmet);
            arif.Subordinates.Add(mehmet);

            OrganisationalStructure organisationalStructure=new OrganisationalStructure(umut);

            PayrollVisitor payrollVisitor=new PayrollVisitor();
            Payrise payrise=new Payrise();

            organisationalStructure.Accept(payrollVisitor);
            organisationalStructure.Accept(payrise);

            Console.ReadLine();
        }
    }

    class OrganisationalStructure
    {
        private EmployeeBase Employee;

        public OrganisationalStructure(EmployeeBase firstEmployee)
        {
            Employee = firstEmployee;
        }

        public void Accept(VisitorBase visitor)
        {
            Employee.Accept(visitor);
        }
    }

    abstract class EmployeeBase
    {
        public abstract void Accept(VisitorBase visitor);
        public string Name { get; set; }
        public decimal Salary { get; set; }
    }

    class Manager:EmployeeBase
    {
        public Manager()
        {
            Subordinates=new List<EmployeeBase>();
        }
        public List<EmployeeBase> Subordinates { get; set; }
        public override void Accept(VisitorBase visitor)
        {
            visitor.Visit(this);

            foreach (var employee in Subordinates)
            {
                employee.Accept(visitor);   
            }
        }
    }

    class Worker:EmployeeBase
    {
        public override void Accept(VisitorBase visitor)
        {
            visitor.Visit(this);
        }
    }

    abstract class VisitorBase
    {
        public abstract void Visit(Manager manager);
        public abstract void Visit(Worker worker);

    }

    class PayrollVisitor:VisitorBase
    {
        public override void Visit(Manager manager)
        {
            Console.WriteLine("{0} paid {1}",manager.Name,manager.Salary);
        }

        public override void Visit(Worker worker)
        {
            Console.WriteLine("{0} paid {1}", worker.Name, worker.Salary);
        }
    }

    class Payrise:VisitorBase 
    {
        public override void Visit(Manager manager)
        {
            Console.WriteLine("{0} salary increased to{1}", manager.Name, manager.Salary*(decimal)1.2);
        }

        public override void Visit(Worker worker)
        {
            Console.WriteLine("{0} salary increased to {1}", worker.Name, worker.Salary*(decimal)1.1);
        }
    }
}
