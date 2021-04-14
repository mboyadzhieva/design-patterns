﻿namespace ObserverPattern
{
    public interface IObservable
    {
        public void Subscribe(IObserver observer);

        public void Unsubscribe(IObserver observer);

        public void Notify();

        public int GetNewValue();
    }
}
