using MolecularSurvivors;
using UnityEngine;
using Zenject;

public class PlayerInstaller : MonoInstaller
{
    [SerializeField] private Player _player;

    public override void InstallBindings()
    {
        BindPlayer();
    }

    private void BindPlayer()
    {/* 
        var player = Container
        .InstantiatePrefabForComponent<Player>(_playerPrefab, Vector3.zero, Quaternion.identity, null); */

        Container.Bind<Player>()
        .FromInstance(_player)
        .AsSingle()
        .NonLazy();
    }
}
