namespace ObserverPattern
{
    public interface IObserver
    {
        public void Update(IObservable observable);
    }
}
