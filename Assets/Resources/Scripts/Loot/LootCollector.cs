using DG.Tweening;
using UnityEngine;

namespace MolecularSurvivors
{
    [RequireComponent(typeof(CircleCollider2D))]
    public class LootCollector : MonoBehaviour
    {
        [SerializeField] private LevelChanger _levelChanger;
        private Player _player;
        private CircleCollider2D _collider;
        private float _radius = .7f;
        private float _collectSpeed = .5f;

        private void Awake()
        {
            _player = GetComponentInParent<Player>();
            _collider = GetComponent<CircleCollider2D>();

            _collider.radius = _radius;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out LootTemplate loot))
            {
                loot.transform.DOMove(_player.transform.position, _collectSpeed).OnComplete(() =>
                {
                    loot.Collect();
                    _levelChanger.IncreaseExperience(loot.Loot.Exp);
                });
            }
        }
    }
}