namespace ObserverPattern
{
    public class Program
    {
        public static void Main()
        {
            var observable = new CovidInfo
            {
                CovidCases = 12
            };

            var observer = new CovidObserver("Nova news");
            observable.Subscribe(observer);

            observable.CovidCases = 1;
            observable.CovidCases = 5;
            observable.CovidCases = 10;

            observable.Unsubscribe(observer);

            /*Console output:
             * Observer added!
               Nova news observer reports updated covid cases: 13
               Nova news observer reports updated covid cases: 18
               Nova news observer reports updated covid cases: 28
               Observer removed!
             */
        }
    }
}
