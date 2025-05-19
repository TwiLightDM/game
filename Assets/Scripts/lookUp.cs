using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class lookUp : MonoBehaviour, IInteractable
{
    public string spriteName;
    [SerializeField] private string message;
    [SerializeField] private GameObject firstObjectToHide; 
    [SerializeField] private GameObject secondObjectToHide;
    [SerializeField] private GameObject ObjectToShow; 
    private bool _sawMessage;
    private float _initialCameraSize;
    private Vector3 _initialCameraPosition;
    [SerializeField] private AudioClip footstepSound;
    [SerializeField] private AudioClip additionalSound;
    private bool _flashLightIsOn;
    private bool _flashLightIsOff;
    
    void Start()
    {
        _initialCameraSize = Camera.main.orthographicSize;
        _initialCameraPosition = Camera.main.transform.position;
    }

    public void Interact(DisplayImage currentDisplay)
    {
        SoundManager.instance.PlaySound(additionalSound);
        SoundManager.instance.PlaySound(footstepSound);

        if (!string.IsNullOrEmpty(message) && !_sawMessage)
        {
            _sawMessage = true;
            tipsManager.displayTipEvent?.Invoke(message);
        }

        currentDisplay.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/" + spriteName);
        currentDisplay.CurrentState = DisplayImage.State.ChangedView;

        Camera.main.orthographicSize = _initialCameraSize;
        Camera.main.transform.position = _initialCameraPosition;

        // Скрываем UI-объект, если он задан
        if (firstObjectToHide != null)
        {
            firstObjectToHide.SetActive(false);
        }
        if (secondObjectToHide != null)
        {
            secondObjectToHide.SetActive(false);
        }
    }
}