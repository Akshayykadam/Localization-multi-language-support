# Unity Multi-Language Support Using CSV

## CSV Table Format:
| Key      | English  | Arabic    | Hindi   |
|----------|---------|---------|---------|
| hello    | Hello   | مرحبًا  | हॅलो   |
| goodbye  | Goodbye | مع السلامة | अलविदा |

## Ways to Add a CSV File for Localization:
### 1. Import the CSV into Unity
- Convert the Excel (.xlsx) file into a CSV format as Unity does not support direct Excel reading.
- Use a CSV Parser (like SimpleCSV) since Unity does not have a built-in CSV parser.
- Place the CSV file in the `StreamingAssets` folder to ensure it is included in the build.
- Read the CSV file in Unity using `System.IO`.

### 2. Use Google Sheets for Remote Localization
- Upload your CSV file to Google Sheets.
- Publish it as a CSV file link.
- Download it using Unity’s `UnityWebRequest`.

## Unity Editor Setup (Step by Step)
### 1. Add a UI Text Field (TextMeshPro)
1. Go to `GameObject → UI → Text`.
2. Rename it to `LocalizedText_Hello`.
3. Change the text to something temporary (e.g., "Default Text").
4. Adjust font size, color, and alignment as needed.
5. Click `Add Component` and attach the `LocalizedText` script.
6. In the Inspector, set the key to `hello` (must match the key in the CSV file).
7. Repeat this step for other text elements, setting different key values.

### 2. Set Up the LocalizationManager
1. Create an empty GameObject in the Hierarchy (`Right-click → Create Empty`).
2. Rename it to `LocalizationManager`.
3. Click `Add Component` and attach the `LocalizationManager` script.
4. In the Inspector, ensure the language field is set to `English` (default).

### 3. Add Buttons for Language Switching
1. Go to `GameObject → UI → Button`.
2. Rename it to `Button_English`.
3. Select the Button and go to the Inspector.
4. Click `Add Component` and attach the `LanguageSwitcher` script.
5. Set `targetLanguage` to `English`.
6. In the Button’s `OnClick()` event:
   - Click `+` to add a new event.
   - Drag and drop the `LocalizationManager` GameObject into the empty field.
   - Select `LanguageSwitcher → ChangeLanguage()` from the dropdown.
7. Repeat these steps for an Arabic Button, setting `targetLanguage` to `Arabic`.
8. Repeat these steps for a Hindi Button, setting `targetLanguage` to `Hindi`.

### 4. Test the Language Switch
1. Press `Play` in Unity.
2. Click the `Arabic` button.
   - The text should change from `Hello` to `مرحبًا`.
3. Click the `Hindi` button.
   - The text should change from `Hello` to `हॅलो`.
4. Click the `English` button.
   - The text should change back to `Hello`.

## Notes
- Ensure your CSV file is properly formatted.
- If using Google Sheets, make sure the file is publicly accessible.
- UnityWebRequest requires an internet connection when fetching data from Google Sheets.
- If translations are not appearing, check the key values in the CSV and ensure they match in the Unity Inspector.

### License
This project is open-source. Feel free to modify and improve!

Happy Coding! 🚀

