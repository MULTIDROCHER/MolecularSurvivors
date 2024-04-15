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
            _window = transform.parent.parent.GetComponentInParent<RewardWindow>();
        }

        public void Set(IReward reward, bool isNew = false)
        {
            _data = reward;

            switch (reward)
            {
                case DefaultReward defaultReward:
                    SetDefault(defaultReward);
                    break;
                case EquipmentReward equipmentReward:
                    SetEquipment(equipmentReward);
                    break;
                default:
                    return;
            }

            _name.text = reward.TextData.Name;
            _description.text = reward.TextData.Description;
            _newEquipmentMark.SetActive(isNew);
        }

        public void SetAsUpgrade(EquipmentData equipment){
            _image.sprite = equipment.Icon;
            _name.text = equipment.TextData.Name;
            var upgrade = equipment.LevelData.ShowNext();
            _description.text = Translator.GetText(upgrade.Description);
            _newEquipmentMark.SetActive(false);
        }

        private void SetDefault(DefaultReward reward) => _image.sprite = reward.Loot.Sprite;

        private void SetEquipment(EquipmentReward reward) => _image.sprite = reward.Data.Icon;

        public void OnPointerClick(PointerEventData eventData)
        {
            _window.RewardSelected(_data);
        }
    }
}