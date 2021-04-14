namespace ObserverPattern
{
    using System;
    using System.Collections.Generic;

    public class CovidInfo : IObservable
    {
        private readonly List<IObserver> observers = new List<IObserver>();
        private int covidCases;

        public int CovidCases 
        { 
            get => this.covidCases;
            set
            {
                this.covidCases += value;
                this.Notify();
            } 
        }

        public void Subscribe(IObserver observer)
        {
            this.observers.Add(observer);
            Console.WriteLine("Observer added!");
        }

        public void Unsubscribe(IObserver observer)
        {
            this.observers.Remove(observer);
            Console.WriteLine("Observer removed!");
        }

        public void Notify()
        {
            foreach (var observer in this.observers)
            {
                observer.Update(this);
            }
        }

        public int GetNewValue()
        {
            return this.CovidCases;
        }
    }
}
