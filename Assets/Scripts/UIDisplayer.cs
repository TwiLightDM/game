using UnityEngine;

public class UIDisplayer : MonoBehaviour, IInteractable
{
    public GameObject DisplayObject;

    public void Interact(DisplayImage currentDisplay)
    {
        DisplayObject.SetActive(true);
    }
}
