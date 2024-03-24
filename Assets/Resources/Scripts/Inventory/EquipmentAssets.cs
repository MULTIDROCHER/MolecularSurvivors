using System.Collections.Generic;
using UnityEngine;

namespace MolecularSurvivors
{
    public class EquipmentAssets : MonoBehaviour
    {
        [SerializeField] private List<WeaponData> _weaponDatas;
        [SerializeField] private List<AbilityData> _abilityDatas;

        private int _randomIndex;

        public EquipmentData GetRandomEquipment()
        {
            _randomIndex = Random.Range(0, _weaponDatas.Count + _abilityDatas.Count);

            if (_randomIndex < _weaponDatas.Count)
                return _weaponDatas[_randomIndex];
            else
                return _abilityDatas[_randomIndex - _weaponDatas.Count];
        }
    }
}