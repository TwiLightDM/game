using UnityEngine;
using UnityEngine.UI;

public class ButtonBehaviour : MonoBehaviour
{
    public enum ButtonId
    {
        RoomChangeButton,
        ReturnButton
    }
    public ButtonId thisButtonid;
    private DisplayImage _currentDisplay;

    void Start()
    {
        _currentDisplay = GameObject.Find("displayImage").GetComponent<DisplayImage>();
    }

    void Update()
    {
        HideDisplay();
        Display();
    }
    
    void HideDisplay()
    {
        if (_currentDisplay.CurrentState == DisplayImage.State.Normal && thisButtonid == ButtonId.ReturnButton)
        {
            GetComponent<Image>().color = new Color(GetComponent<Image>().color.r, GetComponent<Image>().color.g, GetComponent<Image>().color.b, 0);
            GetComponent<Button>().enabled = false;
            transform.SetSiblingIndex(0);
        }

        if (_currentDisplay.CurrentState != DisplayImage.State.Normal && thisButtonid == ButtonId.RoomChangeButton)
        {
            GetComponent<Image>().color = new Color(GetComponent<Image>().color.r, GetComponent<Image>().color.g, GetComponent<Image>().color.b, 0);
            GetComponent<Button>().enabled = false;
            transform.SetSiblingIndex(0);
        }
    }

    void Display()
    {
        if (_currentDisplay.CurrentState != DisplayImage.State.Normal && thisButtonid == ButtonId.ReturnButton)
        {
            GetComponent<Image>().color = new Color(GetComponent<Image>().color.r, GetComponent<Image>().color.g, GetComponent<Image>().color.b, 1);
            GetComponent<Button>().enabled = true;
        }
        
        if (_currentDisplay.CurrentState == DisplayImage.State.Normal && thisButtonid == ButtonId.RoomChangeButton)
        {
            GetComponent<Image>().color = new Color(GetComponent<Image>().color.r, GetComponent<Image>().color.g, GetComponent<Image>().color.b, 1);
            GetComponent<Button>().enabled = true;
        }
    }
    
}
