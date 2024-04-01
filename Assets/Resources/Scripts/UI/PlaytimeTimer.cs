using TMPro;
using UnityEngine;

namespace MolecularSurvivors
{
    [RequireComponent(typeof(TMP_Text))]
    public class PlaytimeTimer : MonoBehaviour
    {
        private readonly float _timeDivider = 60f;
        private readonly string _minutesFormat = "{0:00}";
        private readonly string _secondsFormat = "{1:00}";

        private TMP_Text _display;
        private float _playtime;

        private void Awake()
        {
            _display = GetComponent<TMP_Text>();
        }

        private void Update()
        {
            if (Time.timeScale > 0)
            {
                _playtime += Time.deltaTime;
                UpdateDisplay();
            }
        }

        private void UpdateDisplay()
        {
            int minutes = Mathf.FloorToInt(_playtime / _timeDivider);
            int seconds = Mathf.FloorToInt(_playtime % _timeDivider);
            string timerString = string.Format(_minutesFormat + ":" + _secondsFormat, minutes, seconds);
            _display.text = timerString;
        }
    }
}