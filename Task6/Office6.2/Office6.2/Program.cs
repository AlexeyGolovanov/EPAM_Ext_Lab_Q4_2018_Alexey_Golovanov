namespace Office6._2
{
    using System;

    public delegate void Enter(Person name, DateTime time);

    public delegate void Left(Person name);

    public class Program
    {
        private static void Main()
        {
            InOutProcess office = new InOutProcess();
            Person john = new Person("John");
            Person bill = new Person("Bill");
            Person hugo = new Person("Hugo");

            office.Entered(john, new DateTime(2019, 01, 01, 9, 15, 0));
            office.Entered(bill, new DateTime(2019, 01, 01, 14, 30, 0));
            office.Entered(hugo, new DateTime(2019, 01, 01, 18, 0, 0));

            office.Left(john);
            office.Left(bill);
            office.Left(hugo);

            Console.ReadLine();
        }
    }
}
