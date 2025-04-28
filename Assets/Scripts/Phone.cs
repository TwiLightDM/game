using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Phone : MonoBehaviour,IInteractable
{
    public string unlockItem;
    private GameObject _inventory;
    
   
    [SerializeField] private AudioClip lockedCabinetSound;
    [SerializeField] private AudioClip keySound;
    void Start()
    {
        gameObject.layer = 1;
        _inventory = GameObject.Find("Inventory");
      
    }

    
    public void Interact(DisplayImage currentDisplay)
    {
      
        if (_inventory.GetComponent<Inventory>().CurrentSelectedSlot != null && 
            _inventory.GetComponent<Inventory>().CurrentSelectedSlot.gameObject.transform.GetChild(0)
                .GetComponent<Image>().sprite.name == unlockItem)
        {
            SoundManager.instance.StopSound();
            
            SoundManager.instance.PlaySound(keySound);
            Debug.Log("Вы позвонили в компанию арифлейм");
            
          
        }
        else
        {
            SoundManager.instance.StopSound();
            SoundManager.instance.PlaySound(lockedCabinetSound);
            Debug.Log("Куда звоним?");
        }

    }
}
