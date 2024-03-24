using UnityEngine;

namespace MolecularSurvivors
{
    [CreateAssetMenu(menuName = "Characters/Player")]
    public class PlayerData : CharacterData
    {
        [SerializeField] private WeaponData _startWeapon;
        [SerializeField] private AbilityData _startAbility;

        public WeaponData StartWeapon => _startWeapon;
        public AbilityData StartAbility => _startAbility;
    }
}