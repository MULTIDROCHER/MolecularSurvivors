using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace MolecularSurvivors
{
    public abstract class EventBus : MonoBehaviour
    {
        protected Dictionary<string, List<Callback>> _callbacks = new();

        protected void Subscribe<T>(Action<T> callback, string key)
        {
            if (_callbacks.ContainsKey(key))
                _callbacks[key].Add(new Callback(callback));
            else
                _callbacks.Add(key, new List<Callback>() { new(callback) });

            //_signalCallbacks[key] = _signalCallbacks[key].OrderByDescending(x => x.Priority).ToList();
        }

        protected void Invoke<T>(T signal, string key)
        {
            if (_callbacks.ContainsKey(key))
                foreach (var obj in _callbacks[key])
                {
                    var callback = obj.Signal as Action<T>;
                    callback?.Invoke(signal);
                }
        }

        protected void Unsubscribe<T>(Action<T> callback, string key)
        {
            if (_callbacks.ContainsKey(key))
            {
                var callbackToDelete = _callbacks[key].FirstOrDefault(x => x.Signal.Equals(callback));

                if (callbackToDelete != null)
                    _callbacks[key].Remove(callbackToDelete);
            }
        }
    }
}