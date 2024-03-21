using UnityEngine;

namespace MolecularSurvivors
{
    [CreateAssetMenu(menuName = "Characters/Player")]
    public class PlayerData : CharacterData
    {
        [field: SerializeField] public WeaponData StartWeapon { get; private set; }
        [field: SerializeField] public AbilityData StartAbility { get; private set; }
    }
}