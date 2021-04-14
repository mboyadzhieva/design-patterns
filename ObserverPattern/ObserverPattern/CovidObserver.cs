namespace ObserverPattern
{
    using System;

    public class CovidObserver : IObserver
    {
        private IObservable covidInfo;

        public string Name { get; private set; }

        public CovidObserver(string name)
        {
            this.Name = name;
        }

        public void Update(IObservable observable)
        {
            this.covidInfo = observable;

            if (this.covidInfo == null)
            {
                Console.WriteLine("No observer found!");
                return;
            }

            var newCases = this.covidInfo.GetNewValue();
            Console.WriteLine(this.Name + " observer reports updated covid cases: " + newCases);
        }
    }
}
