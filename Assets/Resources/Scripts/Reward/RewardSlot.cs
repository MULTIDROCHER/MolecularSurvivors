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

        private RewardWindow _window;
        private IReward _data;

        private void Awake()
        {
            //todo remove parent.parent
            _window = transform.parent.parent.GetComponentInParent<RewardWindow>();
        }

        public void Set(IReward reward, bool isNew = false)
        {
            _data = reward;

            if (reward is DefaultReward defaultReward)
                SetDefault(defaultReward);
            else if (reward is EquipmentReward equipmentReward)
                if (isNew)
                    SetNewEquipment(equipmentReward);
                else
                    SetAsUpgrade(equipmentReward);
        }

        private void SetAsUpgrade(EquipmentReward reward)
        {
            _image.sprite = reward.Data.Icon;
            _name.text = reward.Data.TextData.Name;
            _description.text = Translator.GetText(reward.Data.LevelData.ShowNext().Description);
            _newEquipmentMark.SetActive(false);
        }

        private void SetDefault(DefaultReward reward)
        {
            _image.sprite = reward.Loot.Sprite;
            _name.text = reward.TextData.Name;
            _description.text = reward.TextData.Description;
            _newEquipmentMark.SetActive(true);
        }

        private void SetNewEquipment(EquipmentReward reward)
        {
            _image.sprite = reward.Data.Icon;
            _name.text = reward.Data.TextData.Name;
            _description.text = reward.Data.TextData.Description;
            _newEquipmentMark.SetActive(true);
        }

        public void OnPointerClick(PointerEventData eventData) => _window.RewardSelected(_data);
    }
}