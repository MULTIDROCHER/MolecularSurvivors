using System.Collections.Generic;
using UnityEngine;

namespace MolecularSurvivors
{
    public class DropLootManager : MonoBehaviour
    {
        [SerializeField] private List<Loot> _lootList;
        [SerializeField] private LootPool _pool;

        private List<Loot> _possibleItems = new();

        //todo create pool for enable loot with SO from this

        public void Drop(Vector3 position)
        {
            var loot = GetRandomLoot();

            if (loot != null)
            {
                var template = _pool.GetTemplate();

                if (template != null)
                {
                    template.transform.position = position;
                    template.SetLoot(loot);
                }
            }
        }

        private Loot GetRandomLoot()
        {
            int randomChance = Random.Range(1, 101);
            _possibleItems.Clear();

            foreach (var item in _lootList)
            {
                if (randomChance <= item.DropChance)
                    _possibleItems.Add(item);
            }

            if (_possibleItems.Count > 0)
                return _possibleItems[Random.Range(0, _possibleItems.Count)];
            else
                return null;
        }
    }
}