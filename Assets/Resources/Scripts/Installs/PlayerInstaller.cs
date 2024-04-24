using MolecularSurvivors;
using UnityEngine;
using Zenject;

public class PlayerInstaller : MonoInstaller
{
    [SerializeField] private Player _player;
    [SerializeField] private Inventory _inventory;
    [SerializeField] private HealthChangesDisplay _healthChangesDisplay;
    [SerializeField] private LevelProgress _levelProgress;

    public override void InstallBindings()
    {
        Container.Bind<Player>().FromInstance(_player).AsSingle().NonLazy();
        Container.Bind<Inventory>().FromInstance(_inventory).AsSingle().NonLazy();

        Container.Bind<HealthChangesDisplay>().FromInstance(_healthChangesDisplay).AsSingle().NonLazy();
        Container.Bind<LevelProgress>().FromInstance(_levelProgress).AsSingle().NonLazy();
    }
}