using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DynamicObject : MonoBehaviour, IInteractable
{
    public string unlockItem;
    public GameObject changedStateSprite;
    private GameObject _inventory;
    

    void Start()
    {
        changedStateSprite.SetActive(false);
        _inventory = GameObject.Find("Inventory");
       
    }
    

    public void Interact(DisplayImage currentDisplay)
    {
        if (_inventory.GetComponent<Inventory>().CurrentSelectedSlot.gameObject.transform.GetChild(0).GetComponent<Image>().sprite.name==unlockItem|| unlockItem=="")
        {
            changedStateSprite.SetActive(true);
           // _inventory.GetComponent<Inventory>().CurrentSelectedSlot.GetComponent<Slot>().ClearSlot();
            
        }
    }
}
