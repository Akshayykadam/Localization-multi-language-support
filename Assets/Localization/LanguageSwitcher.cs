using UnityEngine;
using UnityEngine.UI;

public class LanguageSwitcher : MonoBehaviour
{
    public string targetLanguage; // Set this in the Unity Inspector

    public void ChangeLanguage()
    {
        Debug.Log("Changing language to: " + targetLanguage);
        LocalizationManager.Instance.SetLanguage(targetLanguage);

        // Update all UI text components
        foreach (LocalizedText textComponent in FindObjectsOfType<LocalizedText>())
        {
            textComponent.UpdateText(targetLanguage);
            Debug.Log("Updated LocalizedText component with key: " + textComponent.key);
        }
    }
}