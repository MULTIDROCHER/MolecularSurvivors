using System;
using UnityEngine;

namespace MolecularSurvivors
{
    [Serializable]
    public class DroppableItem
    {
        [SerializeField] private GameObject _prefab;
        [SerializeField] private float _rate;

        public GameObject Prefab => _prefab;

        public float Rate => _rate;
    }
}