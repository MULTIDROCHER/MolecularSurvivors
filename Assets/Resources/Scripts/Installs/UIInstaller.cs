using MolecularSurvivors;
using UnityEngine;
using Zenject;

public class UIInstaller : MonoInstaller
{
    [SerializeField] private HealthChangesDisplay _healthChangesDisplay;

    public override void InstallBindings()
    {
        Container.Bind<HealthChangesDisplay>().FromInstance(_healthChangesDisplay).AsSingle().NonLazy();
    }
}