using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace MolecularSurvivors
{
    public class EquipmentAssets
    {
        private readonly string _equipmentPath = "ScriptableObjects/Equipment";
        private readonly List<WeaponData> _weaponDatas = new();
        private readonly List<AbilityData> _abilityDatas = new();

        private int _randomIndex;

        public EquipmentAssets()
        {
            _weaponDatas = LoadData<WeaponData>(_equipmentPath);
            _abilityDatas = LoadData<AbilityData>(_equipmentPath);
        }

        public EquipmentData GetRandomEquipment()
        {
            _randomIndex = Random.Range(0, _weaponDatas.Count + _abilityDatas.Count);

            if (_randomIndex < _weaponDatas.Count)
                return _weaponDatas[_randomIndex];
            else
                return _abilityDatas[_randomIndex - _weaponDatas.Count];
        }

        private List<T> LoadData<T>(string path) where T : EquipmentData
        {
            T[] loadedData = Resources.LoadAll<T>(path) ??
            throw new System.Exception($"Failed to load data from path: {path}");

            return loadedData.ToList();
        }
    }
}