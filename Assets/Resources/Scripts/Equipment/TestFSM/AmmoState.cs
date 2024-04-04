using System;
using UnityEngine;

namespace MolecularSurvivors
{
    [Serializable]
    public abstract class AmmoState : ScriptableObject
    {
        public abstract void Enter();

        protected abstract void Exit();
    }
}