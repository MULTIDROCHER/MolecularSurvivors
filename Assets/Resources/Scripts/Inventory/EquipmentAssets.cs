using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace MolecularSurvivors
{
    public class EquipmentAssets
    {
        private readonly string _equipmentPath = "ScriptableObjects/Equipment";

        public List<EquipmentData> Equipment{ get; private set; } = new();

        public EquipmentAssets()
        {
            Equipment = LoadData<EquipmentData>(_equipmentPath);
        }

        private List<T> LoadData<T>(string path) where T : EquipmentData
        {
            T[] loadedData = Resources.LoadAll<T>(path) ??
            throw new System.Exception($"Failed to load data from path: {path}");

            return loadedData.ToList();
        }
    }
}