using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MolecularSurvivors
{
    [CreateAssetMenu(menuName = "Equipment/Weapon")]
    public class WeaponData : ScriptableObject
    {
        [SerializeField] private Ammo _ammo;
        [SerializeField] private int _damage;
        [SerializeField] private float _cooldown;
        [SerializeField] private float _speed;
        [SerializeField] private Vector3 _scale;
        [SerializeField] private float _effectDuration;
        [SerializeField] private TextCode _nameCode;
        [SerializeField] private TextCode _descriptionCode;

        public Ammo Ammo => _ammo;

        public int Damage => _damage;

        public float Cooldown => _cooldown;

        public float Speed => _speed;

        public Vector3 Scale => _scale;

        public float EffectDuration => _effectDuration;

        public string Name => Translator.GetText(_nameCode);

        public string Description => Translator.GetText(_descriptionCode);
    }
}