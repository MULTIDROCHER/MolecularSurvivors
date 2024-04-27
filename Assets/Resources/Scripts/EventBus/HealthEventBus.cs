using System;

namespace MolecularSurvivors
{
    public class HealthEventBus : EventBus
    {
        public void Subscribe<T>(Action<T> callback)
        {
            Subscribe(callback, typeof(T).Name);
        }

        public void Invoke<T>(T signal)
        {
            Invoke(signal, typeof(T).Name);
        }

        public void Unsubscribe<T>(Action<T> callback)
        {
            Unsubscribe(callback, typeof(T).Name);
        }
    }
}