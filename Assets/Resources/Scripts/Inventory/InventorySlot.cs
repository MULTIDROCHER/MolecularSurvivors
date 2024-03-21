using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace MolecularSurvivors
{
    public class InventorySlot : MonoBehaviour
    {
        [SerializeField] private Image _image;
        [SerializeField] private TMP_Text _level;

        public bool Empty { get; private set; } = true;

        public void Set(EquipmentData equipment)
        {
            if (Empty == false)
                return;

            Empty = false;
            _level.text = "666";
            _image.sprite = equipment.Icon;
        }
    }
}