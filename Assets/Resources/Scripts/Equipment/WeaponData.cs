using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace MolecularSurvivors
{
    [CreateAssetMenu(menuName = "Equipment/WeaponData")]
    public class WeaponData : ScriptableObject
    {
        [field: SerializeReference] public TextComponent TextData { get; private set; } = new();
        [field: SerializeReference] public DamageComponent DamageData { get; private set; } = new();
        [field: SerializeReference] public List<ComponentData> Components { get; private set; }
        [field: SerializeField] public Ammo Ammo { get; private set; }

        public bool TryGetData<T>(out T data)
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
        }

        [ContextMenu("Add area data")]
        private void AddAreaData() => Components.Add(new AreaComponent());

        [ContextMenu("Add throwing data")]
        private void AddThrowingData() => Components.Add(new ThrowingComponent());

        [ContextMenu("Add timer data")]
        private void AddTimerData() => Components.Add(new TimerComponent());

        [ContextMenu("Add amount data")]
        private void AddAmountData() => Components.Add(new AmountComponent());

        [ContextMenu("Add duration data")]
        private void AddDurationData() => Components.Add(new DurationComponent());
    }
}