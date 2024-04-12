using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace MolecularSurvivors
{
    public class EnemyEffects : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _deathEffect;
        [SerializeField] private int _maxPoolSize = 10;

        private List<ParticleSystem> _effects = new();

        private void Awake()
        {
            Initialize();
        }

        public void PlayDeathEffect(Vector3 position)
        {
            var effect = _effects.FirstOrDefault(e => e.isPlaying == false);

            if (effect != null)
            {
                effect.transform.position = position;
                effect.Play();
            }
        }

        private void Initialize()
        {
            for (int i = 0; i < _maxPoolSize; i++)
            {
                var effect = Instantiate(_deathEffect, transform);
                _effects.Add(effect);
            }
        }
    }
}
