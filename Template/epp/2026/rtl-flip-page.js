/**

This script uses a MutationObserver to detect when the `lang` attribute on the `<html>` element changes.
This is a reliable way to catch browser-initiated translations, especially in browsers like Firefox.
When a change is detected, it checks if the new language is one of the known RTL languages
and sets the `dir` attribute on the `<html>` tag accordingly.

Copyright (C) 2025-2026 NataljaNeumann@gmx.de

This program is free software; you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation; either version 2 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License along
with this program; if not, write to the Free Software Foundation, Inc.,
51 Franklin Street, Fifth Floor, Boston, MA 02110-1301 USA.

This version is under the GNU GPL license. There is another version
under MIT licence.

Project home: https://github.com/NataljaNeumann/EasyProfessionalPage

*/

// A comprehensive list of RTL language codes
const rtlLanguages = [
    'ar', 'ara',   // Arabic
    'azb',         // South Azerbaijani (often uses Arabic script in Iran)
    'dv', 'div',   // Dhivehi
    'fa', 'fas',   // Persian / Farsi
    'he', 'iw',    // Hebrew
    'ku', 'kur',   // Kurdish (Sorani dialect)
    'ckb',         // Central Kurdish (Sorani)
    'nqo',         // N'Ko
    'ps', 'pus',   // Pashto
    'rhg',         // Rohingya
    'sd', 'snd',   // Sindhi
    'syr',         // Syriac
    'ug', 'uig',   // Uyghur
    'ur', 'urd',   // Urdu
    'yi', 'yid'    // Yiddish
];

const html = document.documentElement;
const originalLang = html.lang;

// Create a new MutationObserver instance
const observer = new MutationObserver(() => {
    // Check if the language has changed from the original
    if (html.lang && html.lang !== originalLang) {
        const langCode = html.lang.substring(0, 2); // Get the two-letter language code

        // Check if the current language is in our RTL list
        if (rtlLanguages.includes(langCode)) {
            html.dir = 'rtl';
        } else {
            html.dir = 'ltr';
        }
    }
});

// Start observing the <html> element for changes to its attributes, specifically 'lang'
observer.observe(html, { attributes: true, attributeFilter: ['lang'] });
