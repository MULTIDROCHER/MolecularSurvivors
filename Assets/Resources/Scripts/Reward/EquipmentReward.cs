using UnityEngine;

namespace MolecularSurvivors
{
    public class EquipmentReward : ScriptableObject, IReward
    {
        public TextComponent TextData => Data.TextData;
        public EquipmentData Data { get; private set; }

        public void Set(EquipmentData data) => Data = data;
    }
}