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

        private RewardWindow _window;
        private EquipmentData _data;

        private void Awake()
        {
            _window = transform.parent.parent.GetComponentInParent<RewardWindow>();
        }

        //todo rewrite for ireward not only for equipment
        public void Set(EquipmentData data)
        {
            _data = data;
            _image.sprite = data.Icon;
            _name.text = data.TextData.Name;
            _description.text = data.TextData.Description;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            _window.RewardSelected(_data);
        }
    }
}