using System;
using UnityEngine;

namespace MolecularSurvivors
{
    public abstract class CountChanger : MonoBehaviour
    {
        public abstract event Action<int> CountChanged;
    }
}