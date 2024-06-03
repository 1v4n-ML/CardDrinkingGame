using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TextMeshProToggleButton : MonoBehaviour
{
    public TextMeshProUGUI button;
    
    [SerializeField]
    private Sprite OnSprite;

    [SerializeField]
    private Sprite OffSprite;
    public bool isToggled;

    void Start()
    {
        UpdateButtonState();
    }

    public void Toggle()
    {
        isToggled = !isToggled;
        UpdateButtonState();
    }

    void UpdateButtonState()
    {
        if (isToggled)
        {
            GetComponent<Image>().sprite = OnSprite;
            button.text = "USE IN DECK";
        }
        if (!isToggled)
        {
            GetComponent<Image>().sprite = OffSprite;
            button.text = "DONT USE IN DECK";
        }
    }
}
