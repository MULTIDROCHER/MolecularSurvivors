using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace MolecularSurvivors
{
    public class KillsCounter : MonoBehaviour
    {
        [SerializeField] private TMP_Text _text;

        private int _kills;

        public void UpdateCount()
        {
            _kills++;
            _text.text = _kills.ToString();
        }
    }
}
