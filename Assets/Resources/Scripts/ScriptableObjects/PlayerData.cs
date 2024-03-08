using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MolecularSurvivors
{
    [CreateAssetMenu(menuName = "Characters/Player")]
    public class PlayerData : CharacterData
    {
        [SerializeField] private float _recovery;
        [SerializeField] private float _projectileSpeed;
        [SerializeField] private GameObject _startWeapon;

        public int Level { get; private set; } = 1;

        public float Recovery => _recovery;

        public float ProjectileSpeed => _projectileSpeed;
    }
}