using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    class Program
    {
        static void Main(string[] args)
        {
            var customerManager = CustomerManager.CreateAsSingleton();
            customerManager.Save();
        }
    }

    class CustomerManager
    {
        private static CustomerManager _customerManager;
        private static object _lockobject = new object();
        private CustomerManager()
        {
              
        }

        public static CustomerManager CreateAsSingleton()
        {
            lock (_lockobject)
            {
                if (_customerManager == null)
                {
                    _customerManager = new CustomerManager();

                }
            }

            return _customerManager;
        }

        public void Save()
        {
            Console.WriteLine("Saved");
        }
    }
}
