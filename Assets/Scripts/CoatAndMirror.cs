using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CoatAndMirror : MonoBehaviour, IInteractable
{ 
    public string spriteName;
   private float _initialCameraSize;
   private Vector3 _initialCameraPosition;
   [SerializeField] private AudioClip footstepSound;
   [SerializeField] private AudioClip additionalSound;
   [SerializeField] private GameObject toMirror;
   public string unlockItem;
   private GameObject _inventory;
   private bool _coatUnlocked;
   [SerializeField] private string message;
   
   
   void Start()
   {
      _initialCameraSize = Camera.main.orthographicSize;
      _initialCameraPosition = Camera.main.transform.position;
      _inventory = GameObject.Find("Inventory");
      _coatUnlocked = false;
   }
   public void Interact(DisplayImage currentDisplay)
   {
      if(!string.IsNullOrEmpty(unlockItem) &&_coatUnlocked == false){
          if (_inventory.GetComponent<Inventory>().CurrentSelectedSlot != null && 
                _inventory.GetComponent<Inventory>().CurrentSelectedSlot.gameObject.transform.GetChild(0)
                    .GetComponent<Image>().sprite.name == unlockItem)
            {
                
                Debug.Log("Вы надели пальто");
                _inventory.GetComponent<Inventory>().CurrentSelectedSlot.GetComponent<Slot>().ClearSlot();
                _coatUnlocked = true;
                Debug.Log("Сохраняем состояние");
                SoundManager.instance.PlaySound(additionalSound);
                SoundManager.instance.PlaySound(footstepSound);
                
                currentDisplay.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/" + spriteName);
                currentDisplay.CurrentState = DisplayImage.State.ChangedView;
                
                Camera.main.orthographicSize = _initialCameraSize;
                Camera.main.transform.position = _initialCameraPosition;
                
                if(toMirror != null)
                {
                    CoatAndMirror toMirrorScript = toMirror.GetComponent<CoatAndMirror>();
                    if(toMirrorScript != null)
                    {
                        toMirrorScript.spriteName = "Mirror with coat";
                    }
                }
            }
            else
            {
                
                Debug.Log("А?");
            }
      }
      
      else if (_coatUnlocked == true&& string.IsNullOrEmpty(unlockItem)){
         SoundManager.instance.PlaySound(additionalSound);
         SoundManager.instance.PlaySound(footstepSound);
         
         currentDisplay.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/Mirror with coat");
         currentDisplay.CurrentState = DisplayImage.State.ChangedView;
        
         Camera.main.orthographicSize = _initialCameraSize;
         Camera.main.transform.position = _initialCameraPosition;
      }
      else if (_coatUnlocked == false && string.IsNullOrEmpty(unlockItem))
      {
          
          SoundManager.instance.PlaySound(additionalSound);
          SoundManager.instance.PlaySound(footstepSound);
          if(toMirror != null)
          {
              CoatAndMirror toMirrorScript = toMirror.GetComponent<CoatAndMirror>();
              if(toMirrorScript != null)
              {
                  if (toMirrorScript.spriteName != "Mirror with coat")
                  {
                      tipsManager.displayTipEvent?.Invoke(message);
                  }
              }
          }
          
          currentDisplay.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/"+ spriteName);
          currentDisplay.CurrentState = DisplayImage.State.ChangedView;
         
          Camera.main.orthographicSize = _initialCameraSize;
          Camera.main.transform.position = _initialCameraPosition;
      }
   }
}
