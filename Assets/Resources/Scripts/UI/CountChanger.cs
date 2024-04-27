using UnityEngine;
using Zenject;

namespace MolecularSurvivors
{
    public abstract class CountChanger : MonoBehaviour
    {
        [Inject] private readonly CountDisplayEventBus _eventBus;

        [SerializeField] private CountableType _type;

        protected void CountChanged(int amount) => _eventBus.Invoke(new CountChangedSignal(_type, amount));
    }
}