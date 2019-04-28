using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite
{
    class Program
    {
        static void Main(string[] args)
        {

            Employee umut = new Employee { Name = "Umut Sepetci" };

            Employee arif =new Employee{Name = "Arif Sepetci"};

            umut.AddSubordinate(arif);

            Employee ahmet = new Employee {Name = "Ahmet Yıldız"};

            umut.AddSubordinate(ahmet);

            Employee mert = new Employee {Name = "Mert Şavkar"};

            arif.AddSubordinate(mert);

            Contractor berkan = new Contractor{Name="Berkan Balkan"};

            ahmet.AddSubordinate(berkan);
            Console.WriteLine(umut.Name);
            foreach (Employee manager in umut)
            {
                Console.WriteLine(" {0}",manager.Name);
                foreach (IPerson employee in manager)
                {
                    Console.WriteLine("   {0}",employee.Name);
                }

                
            }

            Console.ReadLine();
        }
    }

    interface IPerson
    {
       string Name { get; set; } 
    }

    class Contractor : IPerson
    {
        public string Name { get; set; }
    }


    class Employee :IPerson,IEnumerable<IPerson>
    {
        List<IPerson> _subordinates=new List<IPerson>();

        public void AddSubordinate(IPerson person)
        {
            _subordinates.Add(person);
        }

        public void RemoveSubordinate(IPerson person)
        {
            _subordinates.Remove(person);
        }

        public IPerson GetSubordinate(int index)
        {
            return _subordinates[index];
        }

       
        public string Name { get; set; }
        public IEnumerator<IPerson> GetEnumerator() //hazır yapı
        {
            foreach (var subordinate in _subordinates)
            {
                yield return subordinate;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
