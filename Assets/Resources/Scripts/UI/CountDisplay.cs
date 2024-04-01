using TMPro;
using UnityEngine;

namespace MolecularSurvivors
{
    [RequireComponent(typeof(TMP_Text))]
    public class CountDisplay : MonoBehaviour
    {
        [SerializeField] private CountChanger _countChanger;

        private TMP_Text _text;
        private int _count;

        private void Awake() => _text = GetComponent<TMP_Text>();

        private void OnEnable() => _countChanger.CountChanged += UpdateCount;

        private void OnDisable() => _countChanger.CountChanged -= UpdateCount;

        public void UpdateCount(int amount)
        {
            _count += amount;
            _text.text = _count.ToString();
        }
    }
}