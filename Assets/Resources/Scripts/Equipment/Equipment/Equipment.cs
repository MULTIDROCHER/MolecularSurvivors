using UnityEngine;

namespace MolecularSurvivors
{
    public abstract class Equipment<T> : MonoBehaviour where T : EquipmentData
    {
        public EquipmentController<T> EquipmentController { get; private set; }

        public T Data { get; private set; }

        public virtual void Initialize(T data, EquipmentController<T> controller)
        {
            Data = data;
            EquipmentController = controller;
            gameObject.name = Data.name;
            data.LevelData.Initialize(data);
        }

        public abstract void Execute();

        protected virtual void OnDisable()
        {
            StopAllCoroutines();
        }
    }
}