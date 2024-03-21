using System.Collections.Generic;
using YG;

namespace MolecularSurvivors
{
    public static class Translator
    {
        private const string Ru = "ru";
        private const string En = "en";
        private const string Tr = "tr";

        private static string Language => YandexGame.savesData.language;

        private static readonly Dictionary<TextCode, Dictionary<string, string>> _translates = new()
        {
            { TextCode.GarlicName, new Dictionary<string, string>()
                {
                    { Ru, "Чеснок" },
                    { En, "Garlic" },
                    { Tr, "Sarımsak" }
                }
            },
            { TextCode.GarlicDescription, new Dictionary<string, string>()
                {
                    { Ru, "Наносит урон ближайшим врагам. Снижает сопротивляемость к отбросу и замораживанию." },
                    { En, "Damages nearby enemies. Reduces resistance to knockback and freeze." },
                    { Tr, "Yakındaki düşmanlara zarar verir. Geri tepme ve donmaya karşı direnci azaltır.	" }
                }
            },
            { TextCode.KnifeName, new Dictionary<string, string>()
                {
                    { Ru, "Нож" },
                    { En, "Knife" },
                    { Tr, "Bıçak" }
                }
            },
            { TextCode.KnifeDescription, new Dictionary<string, string>()
                {
                    { Ru, "Быстро стреляет в направлении лица." },
                    { En, "Fires quickly in the faced direction." },
                    { Tr, "Karşı tarafa doğru hızla ateş eder." }
                }
            },
            { TextCode.Default, new Dictionary<string, string>()
                {
                    { Ru, "idk.null.." },
                    { En, "idk.null.." },
                    { Tr, "idk.null.." }
                }
            },
        };

        public static string GetText(TextCode code)
        {
            return Language switch
            {
                Ru => _translates[code][Ru],
                Tr => _translates[code][Tr],
                En => _translates[code][En],
                _ => "null",
            };
        }
    }
}