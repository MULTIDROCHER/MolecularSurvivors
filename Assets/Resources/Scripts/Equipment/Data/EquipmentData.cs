using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace MolecularSurvivors
{
    public abstract class EquipmentData : ScriptableObject
    {
        [field: SerializeReference] public Sprite Icon { get; private set; }
        [field: SerializeReference] public TextComponent TextData { get; private set; } = new();
        /* [field: SerializeReference] public List<ComponentData> Components { get; private set; }

        #region Context Menu 
        [ContextMenu("Add area data")]
        private void AddAreaData() => Components.Add(new AreaComponent());

        [ContextMenu("Add throwing data")]
        private void AddSpeedData() => Components.Add(new SpeedComponent());

        [ContextMenu("Add duration data")]
        private void AddDurationData() => Components.Add(new DurationComponent());
        #endregion*/

        /* public bool TryGetData<T>(out T data)
        {
            data = Components.OfType<T>().FirstOrDefault();
            return data != null;
        }

        public T RequireComponent<T>() where T : ComponentData, new()
        {
            if (TryGetData(out T component) == false)
            {
                component = new T();
                Components.Add(component);
            }

            return component;
        } */
    }
}