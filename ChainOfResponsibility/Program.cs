using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResponsibility
{
    class Program
    {
        static void Main(string[] args)
        {

            Manager manager=new Manager();
            VicePresident vicePresident=new VicePresident();
            President president=new President();

            manager.SetSuccessor(vicePresident);
            vicePresident.SetSuccessor(president);

            Expense expense=new Expense{Detail = "Training",Amount = 2000};
            manager.HandleExpanse(expense);

            Console.ReadLine();
        }
    }

    class Expense
    {
        public string Detail { get; set; }
        public decimal Amount { get; set; }
    }

    abstract class ExpenseHandlerBase
    {
        protected ExpenseHandlerBase Successor;

        public abstract void HandleExpanse(Expense expense);

        public void SetSuccessor(ExpenseHandlerBase successor)
        {
            Successor = successor;
        }

        
    }

    class Manager : ExpenseHandlerBase
    {
        public override void HandleExpanse(Expense expense)
        {
            if (expense.Amount<=100)
            {
                Console.WriteLine("Manager handled the expense");
            }
            else if(Successor!=null)
            {
                Successor.HandleExpanse(expense);
            }
        }
    }


    class VicePresident : ExpenseHandlerBase
    {
        public override void HandleExpanse(Expense expense)
        {
            if (expense.Amount > 100 && expense.Amount<=1000)
            {
                Console.WriteLine("Vice president handled the expense");
            }
            else if (Successor != null)
            {
                Successor.HandleExpanse(expense);
            }
        }
    }

    class President : ExpenseHandlerBase
    {
        public override void HandleExpanse(Expense expense)
        {

            if (expense.Amount >1000)
            {
                Console.WriteLine("President handled the expense");
            }
        }
    }
}
