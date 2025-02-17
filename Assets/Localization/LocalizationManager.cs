using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class LocalizationManager : MonoBehaviour
{
    public static LocalizationManager Instance;
    private Dictionary<string, string> localizedText;
    public string language = "English"; // Default language
    public Font arabicFont;
    public Font hindiFont;
    public Font defaultFont;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            LoadLocalization();
            StartCoroutine(DownloadLocalizationData());
        }
    }

    public void LoadLocalization()
    {
        localizedText = new Dictionary<string, string>();
        string filePath = Path.Combine(Application.streamingAssetsPath, "Localization.csv");
        Debug.Log("LocalizationManager: Attempting to load localization file from: " + filePath);

        if (File.Exists(filePath))
        {
            string[] lines = File.ReadAllLines(filePath);
            if (lines.Length == 0)
            {
                Debug.Log("LocalizationManager: Localization file is empty!");
                return;
            }

            string[] headers = lines[0].Split(',');
            int languageIndex = 1;

            for (int i = 1; i < headers.Length; i++)
            {
                if (headers[i].Trim().Equals(language, System.StringComparison.OrdinalIgnoreCase))
                {
                    languageIndex = i;
                    Debug.Log("LocalizationManager: Selected language found: " + language);
                    break;
                }
            }

            for (int i = 1; i < lines.Length; i++)
            {
                string[] columns = lines[i].Split(',');
                if (columns.Length > languageIndex)
                {
                    localizedText[columns[0]] = columns[languageIndex];
                    Debug.Log("LocalizationManager: Loaded key: " + columns[0] + " | Value: " + columns[languageIndex]);
                }
                else
                {
                    Debug.Log("LocalizationManager: Skipping line " + i + " due to missing data.");
                }
            }
        }
        else
        {
            Debug.Log("LocalizationManager: Localization file not found!");
        }
    }

    public string GetLocalizedText(string key)
    {
        if (localizedText.ContainsKey(key))
        {
            Debug.Log("LocalizationManager: Fetching localized text for key: " + key);
            return localizedText[key];
        }
        else
        {
            Debug.LogWarning("LocalizationManager: Missing localization for key: " + key);
            return key;
        }
    }

    public void SetLanguage(string newLanguage)
    {
        Debug.Log("LocalizationManager: Changing language to: " + newLanguage);
        language = newLanguage;
        LoadLocalization();
    }

    IEnumerator DownloadLocalizationData()
    {
        string url = "https://docs.google.com/spreadsheets/d/e/2PACX-1vTlYA5xZHfrV0CXC8gxP4eSJQcl72u2C4VvNnkHLNC2Y-kY1R5eAIb4o6PEw5ElaLmNq6Avnxt0jiyz/pub?gid=0&single=true&output=csv";
        UnityWebRequest www = UnityWebRequest.Get(url);
        yield return www.SendWebRequest();

        if (www.result == UnityWebRequest.Result.Success)
        {
            Debug.Log("LocalizationManager: Downloading Localization Data");

            string filePath = Path.Combine(Application.dataPath, "StreamingAssets/LocalizationFromWeb.csv");
            File.WriteAllText(filePath, www.downloadHandler.text);

            Debug.Log("LocalizationManager: Downloaded Localization Data Successfully");
            Debug.Log("LocalizationManager: Localization file saved at: " + filePath);
        }
        else
        {
            Debug.Log("LocalizationManager: Failed to download localization data!");
        }
    }
}
