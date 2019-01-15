namespace Office6._2
{
    using System;

    public class Person
    {
        private const int DayTime = 12;
        private const int EveningTime = 17;
     
        public Person(string name)
        {
            this.Name = name;
        }

        public event Enter OnEnter;

        public event Left OnLeaving;

        public string Name { get; private set; }

        public void Coming(DateTime time)
        {
            this.OnEnter?.Invoke(this, time);
        }

        public void Leave()
        {
            this.OnLeaving?.Invoke(this);
        }

        public string DayStage(DateTime time)
        {
            if (time.Hour < DayTime)
            {
                return strings.Morning;
            }

            if ((time.Hour >= DayTime) && (time.Hour < EveningTime))
            {
                return strings.Afternoon;
            }

            return strings.Evening;
        }

        public void Hello(Person worker, DateTime time)
        {
            Console.WriteLine(strings.Hello, this.DayStage(time), worker.Name, this.Name);
        }

        public void Goodbye(Person worker)
        {
            Console.WriteLine(strings.Goodbye, worker.Name, this.Name);
        }
    }
}
