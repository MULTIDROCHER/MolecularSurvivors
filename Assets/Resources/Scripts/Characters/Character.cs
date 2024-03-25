using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MolecularSurvivors
{
    public abstract class Character<T> : MonoBehaviour where T : CharacterData
    {
        [field: SerializeField] public T Data { get; private set; }
        public CharacterHealth Health { get; private set; }

        protected virtual void Awake()
        {
            Health = GetComponentInChildren<CharacterHealth>();
        }
    }
}
