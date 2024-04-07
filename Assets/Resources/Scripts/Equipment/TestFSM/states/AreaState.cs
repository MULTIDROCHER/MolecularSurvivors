using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MolecularSurvivors
{
    public class AreaState : AmmoState
    {
        [Header("Area State")]
        [SerializeField] private Vector3 _areaScale;

        public override void Enter()
        {
            Debug.Log("Area State enter");
        }

        public override void Update(float deltaTime)
        {
            Debug.Log("Area State");
        }
    }
}