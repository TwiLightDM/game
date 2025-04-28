using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ChangeViewTwice : MonoBehaviour, IInteractable
{
     [Header("Zoom Settings")]
    public float ZoomRatio = 0.5f;
    [SerializeField] private AudioClip footstepSound;
    
    [Header("View Change Settings")]
    public string spriteName;
    public string spriteNameOn;
    public string unlockItem;
    public string unlockItemOff;
    [SerializeField] private AudioClip flashlightSound;
    [Header("Tip")]
    
    [SerializeField] private string firstMessage;
    [SerializeField] private string message;
    private float _initialCameraSize;
    private Vector3 _initialCameraPosition;
    private GameObject _inventory;
    private GameObject _textPanel;
    private DisplayImage _currentDisplay;
    private bool _isZoomed = false;
    // private float checkDelay = 1f; 
    // private float timer = 0f;
    private bool _isFlashlightOn = false;

    void Start()
    {
        _initialCameraSize = Camera.main.orthographicSize;
        _initialCameraPosition = Camera.main.transform.position;
        _inventory = GameObject.Find("Inventory");
        
    }

    public void Interact(DisplayImage currentDisplay)
    {
        _currentDisplay = currentDisplay;
        
        if (!_isZoomed)
        {
            ZoomIn();
        }
        else
        {
            CheckInventoryAndChangeView();
        }
    }

    private void ZoomIn()
    {
        SoundManager.instance.PlaySound(footstepSound);
    
        _initialCameraSize = Camera.main.orthographicSize;
        _initialCameraPosition = Camera.main.transform.position;
    
        Camera.main.orthographicSize *= ZoomRatio;
    
       
        float xOffset = -1.5f; 
        Vector3 zoomPosition = new Vector3(
            this.transform.position.x + xOffset,
            this.transform.position.y+0.9f,
            Camera.main.transform.position.z);
    
        Camera.main.transform.position = zoomPosition;

        _currentDisplay.CurrentState = DisplayImage.State.Zoom;
        _isZoomed = true;
    
        ConstraintCamera();
    }

    

    private void CheckInventoryAndChangeView()
    {
        if (_inventory.GetComponent<Inventory>().CurrentSelectedSlot != null && 
            _inventory.GetComponent<Inventory>().CurrentSelectedSlot.gameObject.transform.GetChild(0)
                .GetComponent<Image>().sprite.name == unlockItem)
        {
            
            Debug.Log("Вы светите фонариком в скважину");
            _isFlashlightOn = true;
            SoundManager.instance.PlaySound(flashlightSound);
            SoundManager.instance.PlaySound(footstepSound);
            _currentDisplay.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/" + spriteNameOn);
        }
        else if (_inventory.GetComponent<Inventory>().CurrentSelectedSlot != null &&
                 _inventory.GetComponent<Inventory>().CurrentSelectedSlot.gameObject.transform.GetChild(0)
                     .GetComponent<Image>().sprite.name == unlockItemOff)
        {
            
            
      
            _isFlashlightOn = false;
            tipsManager.displayTipEvent?.Invoke(message);
           ;
          
            Debug.Log("Фонарик разряжен");
            
            
            
            SoundManager.instance.PlaySound(footstepSound);
            _currentDisplay.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/" + spriteName);
        }
        else
        {
           
            tipsManager.displayTipEvent?.Invoke(firstMessage);
            _isFlashlightOn = false;
          
            Debug.Log("Фонарик разряжен");
           
            SoundManager.instance.PlaySound(footstepSound);
            _currentDisplay.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/" + spriteName);
        }

        _currentDisplay.CurrentState = DisplayImage.State.ChangedView;
        ResetCamera();
        _isZoomed = false;
    }

    private void ResetCamera()
    {
        Camera.main.orthographicSize = _initialCameraSize;
        Camera.main.transform.position = _initialCameraPosition;
        
         
    }
    
    private void ConstraintCamera()
    {
        float height = Camera.main.orthographicSize;
        float width = height * Camera.main.aspect;
        GameObject cameraBounds = GameObject.Find("cameraBounds");

        if (cameraBounds == null) return;

        // Ограничения по X
        float boundsHalfWidth = cameraBounds.GetComponent<BoxCollider2D>().size.x / 2;
        float boundsHalfHeight = cameraBounds.GetComponent<BoxCollider2D>().size.y / 2;
        Vector3 boundsCenter = cameraBounds.transform.position;

        float cameraRight = Camera.main.transform.position.x + width;
        float cameraLeft = Camera.main.transform.position.x - width;
        float cameraTop = Camera.main.transform.position.y + height;
        float cameraBottom = Camera.main.transform.position.y - height;

        Vector3 newPosition = Camera.main.transform.position;

        if (cameraRight > boundsCenter.x + boundsHalfWidth)
        {
            newPosition.x = boundsCenter.x + boundsHalfWidth - width;
        }
        else if (cameraLeft < boundsCenter.x - boundsHalfWidth)
        {
            newPosition.x = boundsCenter.x - boundsHalfWidth + width;
        }

        if (cameraTop > boundsCenter.y + boundsHalfHeight)
        {
            newPosition.y = boundsCenter.y + boundsHalfHeight - height;
        }
        else if (cameraBottom < boundsCenter.y - boundsHalfHeight)
        {
            newPosition.y = boundsCenter.y - boundsHalfHeight + height;
        }

        Camera.main.transform.position = newPosition;
    }
}
