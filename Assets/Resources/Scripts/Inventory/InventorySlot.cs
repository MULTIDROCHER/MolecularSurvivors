using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace MolecularSurvivors
{
    public class InventorySlot : MonoBehaviour
    {
        [SerializeField] private Image _image;
        [SerializeField] private TMP_Text _level;

        public EquipmentData Equipment { get; private set; }

        public bool Empty => Equipment == null;

        public void Set(EquipmentData equipment)
        {
            Equipment = equipment;
            _image.sprite = equipment.Icon;
            _level.text = equipment.LevelData.CurrentLevel + "/" + equipment.LevelData.MaxLevel;
        }
    }
}