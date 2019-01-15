namespace Office6._2
{
    using System;
    using System.Collections.Generic;

    public class InOutProcess
    {
        private readonly List<Person> staff;

        public InOutProcess()
        {
            this.staff = new List<Person>();
        }

        public void Entered(Person employee, DateTime time)
        {
            Console.WriteLine();
            Console.WriteLine(strings.Enter, employee.Name);

            foreach (var p in this.staff)
            {
                employee.OnEnter += p.Hello;
                employee.OnLeaving += p.Goodbye;
                p.OnLeaving += employee.Goodbye;
            }

            this.staff.Add(employee);

            employee.Coming(time);
        }

        public void Left(Person employee)
        {
            Console.WriteLine();
            Console.WriteLine(strings.Leave, employee.Name);
            employee.Leave();
            foreach (var p in this.staff)
            {
                p.OnEnter -= employee.Hello;
                p.OnLeaving -= employee.Goodbye;
            }

            this.staff.Remove(employee);
        }
    }
}
