---
applyTo: "**/*.cs"
---

<!-- This project is licensed under GPL-2.0-or-later. See ../../LICENSE.TXT for the complete license text. -->

# General Instructions

These instructions apply only to source files matching `applyTo`. Project-specific `.editorconfig`, `CONTRIBUTING.md`, and build configuration take precedence if they define a conflicting rule.

Use Hungarian notation. The prefix for bool is "b", the prefix for date and time is "dtm", the prefix for date without time is "dt", the prefix for float is "f", the prefix for double is "dbl", the prefix for byte is "by", prefix for string is "str", the prefix for ints is "n", the prefix for longs is "l", the prefix for chars is "c", the prefix for arrays is "a", the prefix of arrays of strings is "astr", the prefix for text boxes is "tbx", the prefix for labels is "lbl", the prefix for check boxes is "chk", the prefix for buttons is "btn", the prefix for other controls is "ctl", the prefix for other objects is "o". If variables represent physical values, (e.g. pixels, meters, inches, circular degrees, Kelvin, Celsius, Newton, seconds, etc.) then they shall have an additional prefix that represents the units of the variable, e.g. "npx", if this is not possible then the units shall be written in full text in name of the variable or parameter. Member variables have an additional prefix "m_". Static member variables have an additional prefix "s_", instead of "m_". Const variables have an additional prefix "c_" instead of other prefixes. Properties don't have prefixes regarding their types, physical units are written in full text inside the name of the property.

Document the source code, functions, and their parameters. The documentation must be in English. Be generous in commenting the code, explain the situation and what shall be done. XML documentation may use `<b>`, `</b>`, `<i>`, `</i>`, and `<br/>` to format text in IntelliSense. Use `<br/><br/>` to separate paragraphs.

If a string is compared to null, then use == or != comparison. If a string is compared to another string that is not null, then use functions CompareTo or Equals.

When a string shall be composed of several parts, please put the result to a string variable, before using it. Explicitly declare that the variable is of type string. If the string can appear in the GUI, then store it in the appropriate Resx file and format it using "string.Format" method.

When a function with more than two parameters shall be called, please use multiline syntax for calling, put different parameters into different lines, so the line doesn't become too long.

Put every parameter into a separate line in function definitions.

Explicitly declare the types of variables, don't use "var".

If an object is created that implements IDisposable interface, then please take care of its disposal. Either it must be stored in another object that will dispose it, or you need to dispose it explicitly after usage.

If a COM object is created then, please take care of its release. Please take care about reference count of COM objects.

Please take care of localization/internationalization of source code. The used strings need to be taken from resources, so they are localizable for different cultures.

When designing a new method not in the GUI, please design also one or several unit tests for it in a corresponding test project.

Expect any external operation, whether it is a directory, file, database, network operation to fail and design a safe method of handling the failure. Either retry, or show a message. Document expected exceptions in the XML documentation of the methods.

Use Themed controls from the own controls folder, if available. If something is missing, design new themed controls that work correctly for dark and light theme. You may also need to adapt the ThemeManager to work with new Controls. Use Forms.NewMessageBox instead of standard Message Box.

This is a multilingual application. If any strings can appear in the GUI, then store them in Resources of the application or in the resources of the Form. Assume that the text of any exception also can appear in the GUI. Format the strings using the "string.Format" method. Automatically provide translations of the strings in all supported cultures in the correponsing resx files. Take care of different Date and Time formats, some cultures also may have different calendars that are far apart from the western Gregorian calender. Internally use UTC date and time for saving and loading, if time component is important. The dialogs may need to work with light theme, with dark theme, with left-to-right writing direction and with right-to-left writing direction.

Take care, that there may be differences on system with the order of bytes, the data stored at disk must be stored and read in a platform-independent way. Texts are preferably stored in UTF-8 for western cultures and in UTF-16, where it is preferable. Expect different file formats, when loading texts.

Whenever a non-GUI method is designed, also design one or several test methods for it. For GUI methods append the needed test steps (test description and expected result) to an HTML documentation file that contains all steps that need to be done by the user for testing the application.

If a method must throw an exception inside a test, then instead of expecting an exception outside of a mathod or unit test catch the exception inside the test and verify that it was there. This is faster and more convenient.

Avoid known security issues. Explicitly create tests for testing security, if security is relevant.

## Licensing

This project is licensed under GNU GPL version 2 or later (`GPL-2.0-or-later`).

Generated or modified source code must remain compatible with the project's license. 
Preserve existing copyright and license notices. See [`LICENCE.TXT`](../../LICENCE.TXT) for the complete license text.
