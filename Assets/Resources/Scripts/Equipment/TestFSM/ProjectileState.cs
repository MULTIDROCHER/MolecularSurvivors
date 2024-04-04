using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MolecularSurvivors
{
    [Serializable]
    public class ProjectileState
    {
        [SerializeField] private GameObject _prefab;

        public void Enter(Transform target)
        {
            throw new System.NotImplementedException();
        }

        protected void Exit()
        {
            throw new System.NotImplementedException();
        }
    }
}
