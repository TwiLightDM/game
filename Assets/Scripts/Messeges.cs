using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Messeges : MonoBehaviour, IInteractable
{
    private bool _sawMessage;
    [SerializeField] private string message;
    [SerializeField] private AudioClip footstepSound;
    [SerializeField] private AudioClip additionalSound;
    public void Interact(DisplayImage currentDisplay)
    {
      
        SoundManager.instance.PlaySound(additionalSound);
        SoundManager.instance.PlaySound(footstepSound);
        if (!string.IsNullOrEmpty(message))
        {
          
            tipsManager.displayTipEvent?.Invoke(message);
        }
       
    }
}


