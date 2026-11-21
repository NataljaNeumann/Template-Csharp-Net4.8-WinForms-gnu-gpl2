// Template v0.0
// Copyright (C) 2026 NataljaNeumann@gmx.de
//
// This program is free software; you can redistribute it and/or
// modify it under the terms of the GNU General Public License
// as published by the Free Software Foundation; either version 2
// of the License, or (at your option) any later version.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with this program; if not, write to the Free Software
// Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.

using System;
using System.Windows.Forms;
using System.Globalization;
using System.Text;

namespace Template
{
    //*******************************************************************************************************
    /// <summary>
    /// Main class 
    /// </summary>
    //*******************************************************************************************************
    static class Program
    {
        //===================================================================================================
        /// <summary>
        /// Indicates that the application runs in a predominantly islamic country;
        /// </summary>
        public static bool IslamicCountry;


        //===================================================================================================
        /// <summary>
        /// Main entry point of the application
        /// </summary>
        //===================================================================================================
        [STAThread]
        static void Main()
        {
#if DEBUG
            /*
            Testing single cultures

            Code        Native Name             English Name
            ----------  ----------------------  ------------------
            af	        Afrikaans	            Afrikaans
            am	        አማርኛ	                Amharic
            ar	        العربية	                Arabic
            as	        অসমীয়া	                Assamese
            az	        azərbaycan	            Azerbaijani
            be	        Беларуская	            Belarusian
            bg	        български	            Bulgarian
            bn	        বাংলা		                Bangla
            bo-CN	    བོད་ཡིག (ཀྲུང་ཧྭ་མི་དམངས་སྤྱི་མཐུན་རྒྱལ་ཁབ།)		Tibetan (PRC)
            bs	        bosanski	            Bosnian
            ca	        català	                Catalan
            cs	        čeština	                Czech
            da	        dansk	                Danish
            de	        Deutsch	                German
            dz	        རྫོང་ཁ	                    Dzongkha
            el	        Ελληνικά	            Greek
            eo	        esperanto	            Esperanto
            es	        español	                Spanish
            et	        eesti	                Estonian
            fa	        فارسی	                Persian
            fi	        suomi	                Finnish
            fil	        Filipino	            Filipino
            fr	        français	            French
            ga-IE	    Gaeilge (Éire)	        Irish (Ireland)
            he	        עברית	                Hebrew
            hi	        हिन्दी	                    Hindi
            hr	        hrvatski	            Croatian
            hu	        magyar	                Hungarian
            hy	        Հայերեն	                Armenian
            id	        Indonesia	            Indonesian
            ig	        Asụsụ Igbo	            Igbo
            is	        íslenska	            Icelandic
            it	        italiano	            Italian
            ja	        日本語	                Japanese
            ka	        ქართული		            Georgian
            kk	        қазақ тілі	            Kazakh
            km-KH	    ខ្មែរ (កម្ពុជា)	            Khmer (Cambodia)
            kn	        ಕನ್ನಡ	                Kannada
            ko	        한국어	                Korean
            ku-Arab-IQ	کوردیی ناوەڕاست (عێراق)	Central Kurdish (Iraq)
            ky	        кыргызча	            Kyrgyz
            la	        lingua latīna	        Latin
            lo	        ລາວ	                    Lao
            lt	        lietuvių	            Lithuanian
            lv	        latviešu	            Latvian
            mi	        te reo Māori	        Maori
            mk	        македонски	            Macedonian
            ml	        മലയാളം	            Malayalam
            mn-MN	    монгол (Монгол)	        Mongolian (Cyrillic, Mongolia)
            mr	        मराठी	                Marathi
            ms	        Melayu	                Malay
            my	        ဗမာ	                    Burmese
            ne	        नेपाली	                Nepali
            nl	        Nederlands	            Dutch
            no	        norsk	                Norwegian
            or	        ଓଡ଼ିଆ		                Odia
            pa-Arab-PK	پنجابی (پاکستان)	    Punjabi (Islamic Republic of Pakistan)
            pa-IN	    ਪੰਜਾਬੀ (ਭਾਰਤ)	            Punjabi (India)
            pl	        polski	                Polish
            prs	        درى	                    Dari
            fa-AF	    درى	                    Dari
            ps	        پښتو	                Pashto
            pt	        português	            Portuguese
            quz	        Runasimi	            Quechua
            ro	        română	                Romanian
            ru	        русский	                Russian
            rw	        Kinyarwanda	            Kinyarwanda
            sa	        संस्कृत	                Sanskrit
            sd-Arab	    سنڌي	                Sindhi (Arabic)
            sk	        slovenčina	            Slovak
            sl	        slovenščina	            Slovenian
            so	        Soomaali	            Somali
            sq	        shqip	                Albanian
            sr	        srpski	                Serbian
            sv	        svenska	                Swedish
            sw	        Kiswahili	            Kiswahili
            ta	        தமிழ்	                Tamil
            tg	        Тоҷикӣ	                Tajik
            th	        ไทย	                    Thai
            ti	        ትግርኛ	                Tigrinya
            tk	        Türkmen dili	        Turkmen
            tr	        Türkçe	                Turkish
            uk	        українська	            Ukrainian
            ur-PK	    اُردو (پاکستان)	        Urdu (Islamic Republic of Pakistan)
            uz	        o‘zbek	                Uzbek
            vi	        Tiếng Việt	            Vietnamese
            wo	        Wolof	                Wolof
            yo	        Èdè Yorùbá	            Yoruba
            zh-CHS	    中文(简体) 旧版	        Chinese (Simplified) Legacy
            zh-CHT	    中文(繁體) 舊版	        Chinese (Traditional) Legacy
            zh-Hans 	中文(简体)	            Chinese (Simplified)
            zh-Hant	    中文(繁體)	            Chinese (Traditional)

            */


            // string strSetCulture =
            // "af-ZA";
            // "ar-SA";
            // "as";
            // "az-Latn-AZ";
            // "be-BY";
            // "bg-BG";
            // "bn";
            // "bs-Latn-BA";
            // "cs-CZ";
            // "da-DK";
            // "de-DE";
            // "dz";
            // "el-GR";
            // "en-US";
            // "eo";
            // "es-ES";
            // "et-EE";
            // "fa-IR";
            // "fi-FI";
            // "fil";
            // "fr-FR";
            // "he-IL";
            // "hi-IN";
            // "hr";
            // "hu-HU";
            // "hy-AM";
            // "id-ID";
            // "is-IS";
            // "it-IT";
            // "ja-JP";
            // "ka-GE";
            // "kk-KZ";
            // "kn";
            // "km-KH";
            // "ko-KR";
            // "ky-KG";
            // "la";
            // "lo";
            // "lt-LT";
            // "lv-LV";
            // "mi";
            // "mk-MK";
            // "ml";
            // "mn-MN";
            // "mr";
            // "ms-MY";
            // "my";
            // "ne-NP";
            // "nl-NL";
            // "no-NO";
            // "or";
            // "pa-Arab-PK";
            // "pa-IN";
            // "pl-PL";
            // "fa-AF";
            // "ps-AF";
            // "pt-PT";
            // "quz";
            // "ro-RO";
            // "ru-RU";
            // "sa-IN";
            // "sd-Arab";
            // "sk-SK";
            // "sl-SL";
            // "sq";
            // "sr"; 
            // "sv-SE";
            // "sw";
            // "ta";
            // "tg-Cyrl-TJ";
            // "th-TH";
            // "tk";
            // "tr-TR";
            // "uk-UA";
            // "ur-PK";
            // "uz-Latn-UZ";
            // "vi-VN";
            // "zh-TW";
            // "zh-CN";

            // "ga-IE";
            // "ku-Arab-IQ";
            // "ti-ER";
            // "ti-ET";
            // "am-ET";
            // "ig-NG";
            // "yo-NG";
            // "wo-SN";
            // "so-SO";
            // "rw-RW";
            // System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo(strSetCulture);
            // System.Threading.Thread.CurrentThread.CurrentUICulture = new CultureInfo(strSetCulture);

#endif

            var astrIslamicCountries = new[]
            {
                "AF", "DZ", "BH", "BD", "BJ", "BN", "BF", "CM", "TD", "KM",
                "DJ", "EG", "GM", "GN", "ID", "IR", "IQ", "JO", "KZ", "KW",
                "KG", "LB", "LY", "MY", "MV", "ML", "MR", "MA", "MZ", "NE",
                "NG", "OM", "PK", "PS", "QA", "SA", "SN", "SO", "SS", "SD",
                "SY", "TJ", "TG", "TN", "TR", "TM", "AE", "UZ", "EH", "YE"
            };


            string strCultureName = System.Threading.Thread.CurrentThread.CurrentUICulture.Name;
            IslamicCountry = Array.Exists(astrIslamicCountries, code => strCultureName.Contains(code));

            string strSetCulture = Properties.Settings.Default.ChosenCulture;
            if (!string.IsNullOrEmpty(strSetCulture) &&
                !System.Threading.Thread.CurrentThread.CurrentUICulture.IetfLanguageTag.StartsWith(strSetCulture + "-"))
            {
                try
                {
                    System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo(strSetCulture);
                    System.Threading.Thread.CurrentThread.CurrentUICulture = new CultureInfo(strSetCulture);
                }
                catch (Exception oEx)
                {
                    strSetCulture = string.Empty;
                }
            }

            // Ask the user about the preferred language on first run, on second run
            // and on the 20th run, maybe the user wants to change the language
            if (string.IsNullOrEmpty(strSetCulture)
                || Properties.Settings.Default.StartsSinceCultureChange == 1
                || Properties.Settings.Default.StartsSinceCultureChange == 20)
            {
                using (Forms.CultureSelectionForm oCultureDialog =
                    new Forms.CultureSelectionForm(GetAvailableLocalizations()))
                {
                    if (oCultureDialog.ShowDialog() == DialogResult.OK &&
                        !string.IsNullOrEmpty(oCultureDialog.SelectedLanguage))
                    {
                        if (string.IsNullOrEmpty(strSetCulture) || !strSetCulture.Equals(oCultureDialog.SelectedLanguage))
                        {
                            Properties.Settings.Default.ChosenCulture = oCultureDialog.SelectedLanguage;
                            Properties.Settings.Default.StartsSinceCultureChange = 0;
                            Properties.Settings.Default.Save();

                            System.Diagnostics.Process.Start(
                                System.Reflection.Assembly.GetExecutingAssembly().GetName().Name);

                            return;
                        }
                    }

                    // continue counting for asking another time
                    if (Properties.Settings.Default.StartsSinceCultureChange <= 20)
                    {
                        Properties.Settings.Default.StartsSinceCultureChange++;
                        Properties.Settings.Default.Save();
                    }

                    System.Diagnostics.Process.Start(
                        System.Reflection.Assembly.GetExecutingAssembly().GetName().Name);
                    return;
                }
            }

            // continue counting for asking another time
            if (Properties.Settings.Default.StartsSinceCultureChange <= 20)
            {
                Properties.Settings.Default.StartsSinceCultureChange++;
                Properties.Settings.Default.Save();
            }


            Application.EnableVisualStyles();
            try
            {
                Application.SetCompatibleTextRenderingDefault(false);
            }
            catch (Exception oEx)
            {
                // ignore
            }
            Application.Run(new Template.Forms.MainForm());
        }





        //===================================================================================================
        /// <summary>
        /// Scans the application's base directory for satellite localization assemblies and
        /// returns a dictionary of available localization cultures.
        /// Key: culture name string suitable for `new CultureInfo(key)` (lowercase).
        /// Value: culture native name (self-name), e.g. "Deutsch (Deutschland)".
        /// </summary>
        /// <returns>
        /// Dictionary of available localizations where the key is the culture code
        /// and the value is the culture native name.
        /// </returns>
        //===================================================================================================
        public static System.Collections.Generic.SortedDictionary<string, string> GetAvailableLocalizations()
        {
            // dictionary to return: keys are culture codes (lowercase), values are native names
            System.Collections.Generic.SortedDictionary<string, string> oCultureCodes =
                new System.Collections.Generic.SortedDictionary<string, string>(
                    System.StringComparer.InvariantCultureIgnoreCase);

            // base directory of the running application
            string strBaseDir = AppDomain.CurrentDomain.BaseDirectory;

            // assembly name used to compute satellite resource file name (e.g. "Template.resources.dll")
            string strAssemblyName = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name;
            string strResourceFileName = strAssemblyName + ".resources.dll";

            // get all cultures known to .NET
            System.Globalization.CultureInfo[] aCultures =
                System.Globalization.CultureInfo.GetCultures(System.Globalization.CultureTypes.AllCultures);

            StringBuilder oAllCultures = new StringBuilder();
            // iterate through cultures and check for corresponding satellite assembly
            foreach (System.Globalization.CultureInfo oCulture in aCultures)
            {
                // safety: skip null cultures (shouldn't happen) and invariant culture (empty Name)
                if (oCulture == null)
                {
                    continue;
                }

                string strCultureName = oCulture.Name; // e.g. "de-DE"
                if (string.IsNullOrEmpty(strCultureName))
                {
                    // invariant culture has empty Name -> no subdirectory expected
                    if (!oCultureCodes.ContainsKey("en"))
                    {
                        // assume the invariant culture is english
                        oCultureCodes.Add("en", "English");
                    }
                    continue;
                }

                // expected directory for satellite assemblies
                string strCultureDir = System.IO.Path.Combine(strBaseDir, strCultureName);

                // if culture directory does not exist, skip
                if (!System.IO.Directory.Exists(strCultureDir))
                {
                    continue;
                }

                // expected path to satellite resource assembly
                string strResourcePath = System.IO.Path.Combine(strCultureDir, strResourceFileName);

                // if resources assembly not present, skip
                if (!System.IO.File.Exists(strResourcePath))
                {
                    continue;
                }

                // use the culture's native name as the display value (self-name)
                string strNativeName = oCulture.NativeName; // e.g. "Deutsch (Deutschland)"

                // add to dictionary if not already present
                if (!oCultureCodes.ContainsKey(strCultureName))
                {
                    oCultureCodes.Add(strCultureName,
                        char.ToUpper(strNativeName[0], oCulture) + strNativeName.Substring(1));

                    oAllCultures.Append(oCulture.Name + "\t" + oCulture.NativeName + "\t" + oCulture.DisplayName + Environment.NewLine);
                }
            }

#if DEBUG
            string strAllCultures = oAllCultures.ToString();
#endif
            return oCultureCodes;
        }
    }
}
