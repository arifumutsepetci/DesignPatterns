using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediator
{
    class Program
    {
        static void Main(string[] args)
        {
            Mediator mediator=new Mediator();
            
            Teacher umut=new Teacher(mediator);
            umut.Name = "Umut";

            mediator.Teacher = umut;

            Student orkun=new Student(mediator);
            orkun.Name = "Orkun";

            Student arif= new Student(mediator);
            arif.Name = "Arif";

            mediator.Students=new List<Student>{orkun,arif};

            umut.SendNewImageUrl("slide1.jpg");
            umut.RecieveQuestion("is it true", orkun);

            Console.ReadLine();
        }
    }

    abstract class CourseMember
    {
        protected Mediator Mediator;

        protected CourseMember(Mediator mediator)
        {
            Mediator = mediator;
        }
    }

    class Teacher:CourseMember
    {
      

        public Teacher(Mediator mediator) : base(mediator)
        {
        }
        public string Name { get; set; }
        public void RecieveQuestion(string question, Student student)
        {
            Console.WriteLine("Teacher reciveed a question from {0},{1}",student.Name,question);
        }

        public void SendNewImageUrl(string url)
        {
            Console.WriteLine("Teacher changed slide :{0}",url);
            Mediator.UpdateImage(url);
        }

        public void AnswerQuesion(string answer, Student student)
        {
            Console.WriteLine("Teacher answered question {0},{1}",student.Name,answer);
        }
       
    }

    class Student:CourseMember
    {
        public Student(Mediator mediator) : base(mediator)
        {
        }
        public void RecieveImage(string url)
        {
            Console.WriteLine("{1} recieved image: {0}", url,Name );
        }

        public void RecieveAnswer(string answer)
        {
            Console.WriteLine("Student recieved answer:{0}",answer);
        }

        public string Name { get; set; }

        
    }

    class Mediator
    {
        public Teacher Teacher { get; set; }
        public List<Student> Students { get; set; }

        public void UpdateImage(string url)
        {
            foreach (var student in Students)
            {
                student.RecieveImage(url);
            }
        }

        public void SendQuestion(string question, Student student)
        {
            Teacher.RecieveQuestion(question, student);
        }

        public void SendAnswer(string answer, Student student)
        {
            student.RecieveAnswer(answer);
        }
    }
}
