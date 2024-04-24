using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace MolecularSurvivors
{
    public class LootPool : MonoBehaviour
    {
        [SerializeField] private LootTemplate _template;
        [SerializeField] private int _poolSize = 10;

        private ObjectPool<LootTemplate> _pool;

        private void Awake()
        {
            _pool = new(_template, _poolSize, transform);
        }

        public LootTemplate GetTemplate()
        {
            var template = _pool.GetObject();
            template.Collected += OnCollected;

            return template;
        }

        private void OnCollected(LootTemplate template)
        {
            template.Collected -= OnCollected;
            _pool.ReturnObject(template);
        }
    }
}