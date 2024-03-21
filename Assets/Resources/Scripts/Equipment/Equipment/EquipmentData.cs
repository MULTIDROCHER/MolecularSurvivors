using UnityEngine;

namespace MolecularSurvivors
{
    public abstract class EquipmentData : ScriptableObject
    {
        [field: SerializeReference] public Sprite Icon { get; private set; }
        [field: SerializeReference] public TextComponent TextData { get; private set; } = new();
        
        //test prop
        [field: SerializeReference] public Color Color { get; private set; }

        [field: SerializeReference] public TimerComponent TimerData { get; private set; } = new();
        [field: SerializeReference] public DurationComponent DurationData { get; private set; } = new();
    }
}