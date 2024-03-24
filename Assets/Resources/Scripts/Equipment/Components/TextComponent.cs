using UnityEngine;

namespace MolecularSurvivors
{
    public class TextComponent : ComponentData
    {
        [SerializeField] private TranslatableText _nameCode;
        [SerializeField] private TranslatableText _descriptionCode;

        public string Name => Translator.GetText(_nameCode);

        public string Description => Translator.GetText(_descriptionCode);
    }
}