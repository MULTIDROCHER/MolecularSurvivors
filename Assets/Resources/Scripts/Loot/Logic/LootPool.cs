using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace MolecularSurvivors
{
    public class LootPool : MonoBehaviour
    {
        [SerializeField] private LootTemplate _template;
        [SerializeField] private int _poolSize = 10;
        [SerializeField] private int _maxSize = 100;

        private List<LootTemplate> _pool = new();

        private void Awake()
        {
            Initialize();
        }

        private void Initialize()
        {
            for (int i = 0; i < _poolSize; i++)
                _pool.Add(CreateTemplate());
        }

        public LootTemplate GetTemplate()
        {
            var template = _pool.Where(obj => obj.gameObject.activeSelf == false).FirstOrDefault();

            if (template == null && _pool.Count + 1 <= _maxSize)
            {
                template = CreateTemplate();
                _pool.Add(template);
            }

            return template;
        }

        private LootTemplate CreateTemplate()
        {
            var spawned = Instantiate(_template, transform);
            spawned.gameObject.SetActive(false);

            return spawned;
        }
    }
}
