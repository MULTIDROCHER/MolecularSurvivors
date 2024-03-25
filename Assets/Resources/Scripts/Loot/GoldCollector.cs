using TMPro;
using UnityEngine;

namespace MolecularSurvivors
{
    public class GoldCollector : MonoBehaviour
    {
        [SerializeField] private TMP_Text _display;

        private int _count;

        private void Awake() => UpdateDisplay();

        public void Collect(int amount)
        {
            _count += amount;
            UpdateDisplay();
        }

        private void UpdateDisplay() => _display.text = _count.ToString();
    }
}