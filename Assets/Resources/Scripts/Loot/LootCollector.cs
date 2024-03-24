using DG.Tweening;
using UnityEngine;

namespace MolecularSurvivors
{
    [RequireComponent(typeof(CircleCollider2D))]
    public class LootCollector : MonoBehaviour
    {
        [SerializeField] private LevelProgress _progressChanger;
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
                    GetLoot(loot.Loot);
                    loot.Collect();
                });
            }
        }

        private void GetLoot(Loot loot)
        {
            switch (loot)
            {
                case ExpirienceLoot expLoot:
                    _progressChanger.IncreaseExperience(expLoot.Exp);
                    break;
                case HpLoot hpLoot:
                    _player.Health.Recover(hpLoot.HealthRecovery);
                    break;
                case GoldLoot goldLoot:
                    _player.GoldCollector.Collect(goldLoot.Gold);
                    break;
                default:
                    Debug.Log("Loot not found");
                    break;
            }
        }
    }
}