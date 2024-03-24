using System.Collections;
using System.Collections.Generic;
using MolecularSurvivors.Environment;
using UnityEngine;

namespace MolecularSurvivors
{
    [RequireComponent(typeof(DropLootManager))]
    public class BreakablesController : MonoBehaviour
    {
        private DropLootManager _lootManager;

        [field: SerializeField] public List<BreakableObject> Templates { get; private set; }
        [field: SerializeField] public int MaxAmountOnChunk { get; private set; }

        private void Awake() => _lootManager = GetComponent<DropLootManager>();

        public void Spawn(MapChunk chunk)
        {
            var spawner = chunk.BreakablesSpawner;
            spawner.GetController(this);
            spawner.Spawn();
        }

        public void SetLoot(Transform breakable) => _lootManager.InstantiateLoot(breakable.position);
    }
}