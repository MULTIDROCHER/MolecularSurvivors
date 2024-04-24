using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.Pool;

namespace MolecularSurvivors
{
    public class ObjectPool<T> where T : Component
    {
        private readonly T _prefab;
        private readonly Transform _parentTransform;

        public Queue<T> Pool { get; private set; } = new Queue<T>();

        public ObjectPool(T prefab, int initialSize, Transform parentTransform)
        {
            _prefab = prefab;
            _parentTransform = parentTransform;

            for (int i = 0; i < initialSize; i++)
                CreateObject();
        }

        public T GetObject()
        {
            if (Pool.Count == 0)
                CreateObject();

            return Pool.Dequeue();
        }

        public void ReturnObject(T obj)
        {
            obj.gameObject.SetActive(false);
            Pool.Enqueue(obj);
        }

        private void CreateObject()
        {
            var newObj = Object.Instantiate(_prefab, _parentTransform);
            ReturnObject(newObj);
        }
    }
}