using UnityEngine;

namespace MolecularSurvivors
{
    public class Enemy : MonoBehaviour
    {
        [field: SerializeField] public EnemyData Data { get; protected set; }
        public EnemyHealth Health { get; private set; }
        private SpriteRenderer _renderer;

        public Player Player { get; private set; }

        //maybe separete settings like public enemysettings(nomono)
        private void Awake()
        {
            _renderer = GetComponent<SpriteRenderer>();
            Health = GetComponentInChildren<EnemyHealth>();
        }

        public void Initialize(Player player, HealthChangesDisplay healthChanges)
        {
            Player = player;
            Health.Initialize(this, healthChanges);
        }

        public virtual void Set(EnemyData data)
        {
            Data = data;
            _renderer.sprite = Data.Sprite;
            Health.Set(data);
        }
    }
}