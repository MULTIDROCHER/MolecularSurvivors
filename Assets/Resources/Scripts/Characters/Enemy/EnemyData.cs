using UnityEngine;

namespace MolecularSurvivors
{
    [CreateAssetMenu(menuName = "Characters/Enemy")]
    public class EnemyData : CharacterData
    {
        [SerializeField] private int _damage;
        [SerializeField] private float _attackDelay;

        public int Damage => _damage;

        public float AttackDelay => _attackDelay;
    }
}