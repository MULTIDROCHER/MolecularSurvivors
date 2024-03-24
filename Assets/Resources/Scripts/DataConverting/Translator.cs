using YG;

namespace MolecularSurvivors
{
    public static class Translator
    {
        private const string Ru = "ru";
        private const string En = "en";
        private const string Tr = "tr";

        private static string Language => YandexGame.savesData.language;

        public static string GetText(TranslatableText text)
        {
            return Language switch
            {
                Ru => text.Ru,
                Tr => text.Tr,
                En => text.En,
                _ => "null",
            };
        }
    }
}