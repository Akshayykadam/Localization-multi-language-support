using UnityEngine;
using UnityEngine.UI;

public class LocalizedText : MonoBehaviour
{
    public string key;
    private Text textComponent;

    void Start()
    {
        textComponent = GetComponent<Text>();
        Debug.Log("LocalizedText: LocalizedText component initialized for key: " + key);
        UpdateText(LocalizationManager.Instance.language);
    }

    public void UpdateText(string targetLanguage)
    {
        if (LocalizationManager.Instance != null)
        {
            string localizedText = LocalizationManager.Instance.GetLocalizedText(key);
            textComponent.text = localizedText;
            Debug.Log("Updated text for key: " + key + " | New value: " + localizedText);

            // Check if the language is Arabic or Marathi and adjust font & alignment
            if (targetLanguage.ToLower() == "arabic")
            {
                textComponent.font = LocalizationManager.Instance.arabicFont;
                textComponent.alignment = TextAnchor.MiddleRight;
            }
            else if (targetLanguage.ToLower() == "hindi")
            {
                textComponent.font = LocalizationManager.Instance.hindiFont;
                textComponent.alignment = TextAnchor.MiddleLeft;
            }
            else
            {
                textComponent.font = LocalizationManager.Instance.defaultFont;
                textComponent.alignment = TextAnchor.MiddleLeft;
            }
        }
        else
        {
            Debug.Log("LocalizedText: LocalizationManager instance is null. Cannot update text for key: " + key);
        }
    }
}
