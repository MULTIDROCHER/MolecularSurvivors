using DG.Tweening;
using UnityEngine;
using Zenject;

namespace MolecularSurvivors
{
    [RequireComponent(typeof(CircleCollider2D))]
    public class LootCollector : MonoBehaviour
    {
        private readonly float _collectSpeed = .5f;

        [Inject] private ResourceHandler _handler;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out LootTemplate loot))
            {
                loot.transform.DOMove(transform.parent.position, _collectSpeed).OnComplete(() =>
                {
                    loot.Collect();
                    GetLoot(loot.Loot);
                });
            }
        }

        public void GetLoot(Loot loot) => _handler.GetLoot(loot);
    }
}