using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeView : MonoBehaviour, IInteractable
{
   public string spriteName;
   private float _initialCameraSize;
   private Vector3 _initialCameraPosition;

   void Start()
   {
      _initialCameraSize = Camera.main.orthographicSize;
      _initialCameraPosition = Camera.main.transform.position;
   }
   public void Interact(DisplayImage currentDisplay)
   {
      currentDisplay.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/" + spriteName);
      currentDisplay.CurrentState = DisplayImage.State.ChangedView;
      
      Camera.main.orthographicSize = _initialCameraSize;
      Camera.main.transform.position = _initialCameraPosition;
   }
}
