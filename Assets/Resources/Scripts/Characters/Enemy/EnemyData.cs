using UnityEngine;

namespace MolecularSurvivors
{
    [CreateAssetMenu(menuName = "Characters/Enemy")]
    public class EnemyData : CharacterData
    {
        [field: SerializeField] public Sprite Sprite { get; private set; }
        [field: SerializeField] public int Damage { get; private set; }
        [field: SerializeField] public float AttackDelay { get; private set; }
    }
}