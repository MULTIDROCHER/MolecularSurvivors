using System.Collections.Generic;
using UnityEngine;

namespace MolecularSurvivors
{
    public class EquipmentAssets : MonoBehaviour
    {
        [SerializeField] private List<WeaponData> weaponDatas;
        [SerializeField] private List<AbilityData> abilityDatas;

        public EquipmentData GetRandomEquipment()
        {
            var randomIndex = Random.Range(0, weaponDatas.Count + abilityDatas.Count);

            if (randomIndex < weaponDatas.Count)
                return weaponDatas[randomIndex];
            else
                return abilityDatas[randomIndex - weaponDatas.Count];
        }
    }
}