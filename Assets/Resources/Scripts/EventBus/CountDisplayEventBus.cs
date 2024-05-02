using System;

namespace MolecularSurvivors
{
    public class CountDisplayEventBus : EventBus
    {
        public void Subscribe<T>(Action<T> callback, CountableType type) => Subscribe(callback, type.ToString());

        public void Invoke<T>(T signal)
        {
            if (signal is not CountChangedSignal sig)
                return;
            else
                Invoke(signal, sig.Type.ToString());
        }

        public void Unsubscribe<T>(Action<T> callback, CountableType type) => Unsubscribe(callback, type.ToString());
    }
}