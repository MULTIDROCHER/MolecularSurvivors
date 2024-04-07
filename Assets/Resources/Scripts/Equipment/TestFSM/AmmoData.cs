using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MolecularSurvivors
{
    [CreateAssetMenu(menuName = "Equipment/Ammo", fileName = "AmmoData")]
    public class AmmoData : ScriptableObject
    {
        [field: SerializeField] public Ammo Template { get; private set; }
        [field: SerializeReference] public List<AmmoState> States { get; private set; }

        #region States
        [ContextMenu(nameof(AddProjectileState))] void AddProjectileState() => States.Add(new ProjectileState());
        [ContextMenu(nameof(AddAreaState))] void AddAreaState() => States.Add(new AreaState());
        #endregion
    }
}
