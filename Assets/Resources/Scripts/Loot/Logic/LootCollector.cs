using DG.Tweening;
using UnityEngine;

namespace MolecularSurvivors
{
    [RequireComponent(typeof(CircleCollider2D))]
    public class LootCollector : MonoBehaviour
    {
        private readonly float _collectSpeed = .5f;

        private ResourceHandler _handler;

        private void Start()
        {
            _handler = GetComponentInParent<Player>().ResourceHandler;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out LootTemplate loot))
            {
                loot.transform.DOMove(transform.parent.position, _collectSpeed).OnComplete(() =>
                {
                    _handler.GetLoot(loot.Loot);
                    loot.Collect();
                });
            }
        }
    }
}