using System;
using MolecularSurvivors;
using UnityEngine;
using Zenject;

public class SystemInstaller : MonoInstaller
{
    [SerializeField] private Inventory _inventory;
    [SerializeField] private LevelProgress _levelProgress;
    [SerializeField] private GoldCollector _goldCollector;
    [SerializeField] private EnemySpawner _enemySpawner;

    public override void InstallBindings()
    {
        Container.Bind<TimeControl>().AsSingle().NonLazy();
        BindInventory();
        BindLevelProgress();
        BindEnemySpawner();
        BindResourceHandler();
    }

    private void BindInventory()
    {
        Container
        .Bind<Inventory>()
        .FromInstance(_inventory)
        .AsSingle()
        .NonLazy();
    }

    private void BindLevelProgress()
    {
        Container
        .Bind<LevelProgress>()
        .FromInstance(_levelProgress)
        .AsSingle()
        .NonLazy();
    }

    private void BindEnemySpawner()
    {
        Container
        .Bind<EnemySpawner>()
        .FromInstance(_enemySpawner)
        .AsSingle()
        .NonLazy();
    }

    private void BindResourceHandler()
    {
        BindGoldCollector();
        
        Container
        .Bind<ResourceHandler>()
        .FromNew()
        .AsSingle()
        .NonLazy();
    }

    private void BindGoldCollector()
    {
        Container
        .Bind<GoldCollector>()
        .FromInstance(_goldCollector)
        .AsSingle()
        .NonLazy();
    }
}