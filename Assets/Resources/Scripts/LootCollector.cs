using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace MolecularSurvivors
{
    [RequireComponent(typeof(CircleCollider2D))]
    public class LootCollector : MonoBehaviour
    {
        private LevelChanger _player;
        private CircleCollider2D _collider;
        private float _radius = .7f;
        private float _collectSpeed = .5f;

        private void Awake()
        {
            _player = GetComponentInParent<LevelChanger>();
            _collider = GetComponent<CircleCollider2D>();

            _collider.radius = _radius;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out LootTemplate loot))
            {
                loot.transform.DOMove(_player.transform.position, _collectSpeed).OnComplete(() =>
                {
                    Debug.Log("collected " + loot.gameObject.name);
                    loot.Collect();
                    _player.IncreaseExperience(loot.Loot.Exp);
                });
            }
        }
    }
}