using UnityEngine;

public class UIDisplayer : MonoBehaviour, IInteractable
{
    public GameObject DisplayObject;
    [SerializeField] private AudioClip additionalSound;

    public void Interact(DisplayImage currentDisplay)
    {
        SoundManager.instance.PlaySound(additionalSound);
        DisplayObject.SetActive(true);
    }
}
