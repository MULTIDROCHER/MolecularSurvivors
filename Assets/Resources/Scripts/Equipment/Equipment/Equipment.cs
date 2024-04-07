using UnityEngine;

namespace MolecularSurvivors
{
    public abstract class Equipment<T> : MonoBehaviour where T : EquipmentData
    {
        public EquipmentController<T> Controller { get; private set; }

        public T Data { get; private set; }

        public virtual void Initialize(T data, EquipmentController<T> controller)
        {
            Data = data;
            Controller = controller;
            gameObject.name = Data.name;
        }

        public abstract void Execute();

        private void OnDisable()
        {
            StopAllCoroutines();
        }
    }
}