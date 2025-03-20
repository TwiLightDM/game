using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Drawer : MonoBehaviour, IInteractable
{
    public string unlockItem;
    private GameObject _inventory;

    void Start()
    {
        _inventory = GameObject.Find("Inventory");
    }

    public void Interact(DisplayImage currentDisplay)
    {
        if (_inventory.GetComponent<Inventory>().CurrentSelectedSlot.gameObject.transform.GetChild(0)
                .GetComponent<Image>().sprite.name == unlockItem)
        {
            Debug.Log("unlock");
            // _inventory.GetComponent<Inventory>().CurrentSelectedSlot.GetComponent<Slot>().ItemProperty =
            //     Slot.Property.Empty;
            // _inventory.GetComponent<Inventory>().CurrentSelectedSlot.gameObject.transform.GetChild(0)
            //     .GetComponent<Image>().sprite = Resources.Load<Sprite>("Inventory Items/empty_item");
            _inventory.GetComponent<Inventory>().CurrentSelectedSlot.GetComponent<Slot>().ClearSlot();
        }
    }
}
