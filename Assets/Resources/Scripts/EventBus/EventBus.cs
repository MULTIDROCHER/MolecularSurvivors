using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace MolecularSurvivors
{
    public class EventBus : MonoBehaviour
    {
        private Dictionary<string, List<Callback>> _signalCallbacks = new();

        public void Subscribe<T>(Action<T> callback)
        {
            string key = typeof(T).Name;
            if (_signalCallbacks.ContainsKey(key))
            {
                _signalCallbacks[key].Add(new Callback(callback));
                Debug.Log("added existing for " + key);
            }
            else
            {
                _signalCallbacks.Add(key, new List<Callback>() { new(callback) });
                Debug.Log("added new for " + key);
            }

            //_signalCallbacks[key] = _signalCallbacks[key].OrderByDescending(x => x.Priority).ToList();
        }

        public void Invoke<T>(T signal)
        {
            string key = typeof(T).Name;
            if (_signalCallbacks.ContainsKey(key))
            {
                foreach (var obj in _signalCallbacks[key])
                {
                    var callback = obj.Signal as Action<T>;
                    callback?.Invoke(signal);
                }
            }
            else
            {
                Debug.Log("No invokes for " + key);
            }
        }

        public void Unsubscribe<T>(Action<T> callback)
        {
            string key = typeof(T).Name;

            if (_signalCallbacks.ContainsKey(key))
            {
                var callbackToDelete = _signalCallbacks[key].FirstOrDefault(x => x.Signal.Equals(callback));

                if (callbackToDelete != null)
                    _signalCallbacks[key].Remove(callbackToDelete);
            }
            else
            {
                Debug.LogErrorFormat("Trying to unsubscribe for not existing key! {0} ", key);
            }
        }
    }
}