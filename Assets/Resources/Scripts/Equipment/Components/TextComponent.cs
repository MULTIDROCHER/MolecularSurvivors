using UnityEngine;

namespace MolecularSurvivors
{
    public class TextComponent : ComponentData
    {
        [SerializeField] private TextCode _nameCode;
        [SerializeField] private TextCode _descriptionCode;

        public string Name => Translator.GetText(_nameCode);

        public string Description => Translator.GetText(_descriptionCode);
    }
}