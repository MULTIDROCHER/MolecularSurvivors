using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

namespace MolecularSurvivors
{
    public abstract class EquipmentData : ScriptableObject
    {
        [field: SerializeReference] public Sprite Icon { get; private set; }
        [field: SerializeReference] public TextComponent TextData { get; private set; } = new();
        [field: SerializeReference] public TimerComponent TimerData { get; private set; } = new();
        [field: SerializeReference] public UpgradeComponent LevelData { get; private set; } = new();

        [field: SerializeReference] public List<ComponentData> Components { get; protected set; } = new();

        public ComponentData GetComponent(ComponentType type)
        {
            var component = Components.FirstOrDefault(comp => comp.Type == type);

            if (component == null)
                Debug.Log("wtf null component");

            return component;
        }

        public bool HasComponent(ComponentType type) => GetComponent(type) != null;

        #region Editor
        [ContextMenu(nameof(AddDurationComponent))] private void AddDurationComponent() => Components.Add(new DurationComponent());
        [ContextMenu(nameof(AddAreaComponent))] private void AddAreaComponent() => Components.Add(new AreaComponent());
        [ContextMenu(nameof(ClearComponents))] private void ClearComponents() => Components.Clear();
        #endregion
    }
}