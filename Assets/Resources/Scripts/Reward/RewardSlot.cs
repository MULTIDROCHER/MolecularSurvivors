using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace MolecularSurvivors
{
    public class RewardSlot : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private Image _image;
        [SerializeField] private TMP_Text _name;
        [SerializeField] private TMP_Text _description;
        [SerializeField] private GameObject _newEquipmentMark;

        private IReward _data;

        public event Action<IReward> RewardSelected;

        public void Set(IReward reward, bool isNew = false)
        {
            _data = reward;
            _newEquipmentMark.SetActive(isNew);

            if (reward is DefaultReward common)
                Set(common.Loot.Sprite,
                common.TextData.Name,
                common.TextData.Description);
            else if (reward is EquipmentReward equipment)
            {
                var description = isNew ?
                equipment.Data.TextData.Description : Translator.GetText(equipment.Data.LevelData.ShowNext().Description);
                Set(equipment.Data.Icon, equipment.Data.TextData.Name, description);
            }

            gameObject.SetActive(true);
        }

        private void Set(Sprite sprite, string name, string description)
        {
            _image.sprite = sprite;
            _name.text = name;
            _description.text = description;
        }

        public void OnPointerClick(PointerEventData eventData) => RewardSelected?.Invoke(_data);
    }
}