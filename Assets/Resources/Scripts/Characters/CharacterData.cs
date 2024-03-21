using UnityEngine;

namespace MolecularSurvivors
{
    public abstract class CharacterData : ScriptableObject
    {
        [SerializeField] private float _moveSpeed;
        [SerializeField] private int _maxHealth;
        
        public float MoveSpeed => _moveSpeed;

        public int MaxHealth => _maxHealth;
    }
}
