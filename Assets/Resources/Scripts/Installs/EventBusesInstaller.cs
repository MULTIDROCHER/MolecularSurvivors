using UnityEngine;
using Zenject;

namespace MolecularSurvivors
{
    public class EventBusesInstaller : MonoInstaller
    {
        [SerializeField] private HealthEventBus _eventBus;
        [SerializeField] private CountDisplayEventBus _countDisplayBus;

        public override void InstallBindings()
        {
            Container.Bind<HealthEventBus>().FromInstance(_eventBus).AsSingle().NonLazy();
            Container.Bind<CountDisplayEventBus>().FromInstance(_countDisplayBus).AsSingle().NonLazy();
        }
    }
}
