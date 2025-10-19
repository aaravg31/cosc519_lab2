using UnityEngine;
using UnityEngine.UIElements;

public class UIButtonHandler : MonoBehaviour
{
    private Button openPhoneButton;

    void OnEnable()
    {
        // Access the UIDocument
        var uiDocument = GetComponent<UIDocument>();
        var root = uiDocument.rootVisualElement;

        // Find the button by its name in UXML
        openPhoneButton = root.Q<Button>("openPhoneButton");

        if (openPhoneButton != null)
        {
            // Subscribe to the click event
            openPhoneButton.clicked += OnOpenPhoneClicked;
        }
        else
        {
            Debug.LogWarning("Button not found in UXML!");
        }
    }

    private void OnDisable()
    {
        if (openPhoneButton != null)
            openPhoneButton.clicked -= OnOpenPhoneClicked;
    }

    private void OnOpenPhoneClicked()
    {
        Debug.Log("Button clicked — launching phone hologram!");
        // TODO: Spawn phone or trigger animation here
    }
}
