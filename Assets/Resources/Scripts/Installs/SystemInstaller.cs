using MolecularSurvivors;
using UnityEngine;
using Zenject;

public class SystemInstaller : MonoInstaller
{
    [SerializeField] private Inventory _inventory;
    [SerializeField] private LevelProgress _levelProgress;
    [SerializeField] private EnemySpawner _enemySpawner;
    [SerializeField] private EventBus _eventBus;

    public override void InstallBindings()
    {
        Container.Bind<EventBus>().FromInstance(_eventBus).AsSingle().NonLazy();
        Container.Bind<Inventory>().FromInstance(_inventory).AsSingle().NonLazy();
        Container.Bind<LevelProgress>().FromInstance(_levelProgress).AsSingle().NonLazy();
        Container.Bind<EnemySpawner>().FromInstance(_enemySpawner).AsSingle().NonLazy();
    }
}