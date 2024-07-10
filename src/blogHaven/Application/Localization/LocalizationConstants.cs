using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Localization
{
    public static class LocalizationConstants
    {
        public const string DefaultLanguague = "tr-TR";

        public static readonly LanguageCode[] SupportedLanguages = {
            new LanguageCode
            {
                Code = "en-US",
                DisplayName= "English"
            },
            new LanguageCode
            {
                Code = "pt-BR",
                DisplayName = "Portuguese"
            },
             new LanguageCode
            {
                Code = "tr-TR",
                DisplayName = "Turkish"
            }
        };
    }
}
