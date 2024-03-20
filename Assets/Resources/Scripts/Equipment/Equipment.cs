using UnityEngine;

namespace MolecularSurvivors
{
    public abstract class Equipment<T> : MonoBehaviour where T : EquipmentData
    {
        public abstract void Execute();
    }
}