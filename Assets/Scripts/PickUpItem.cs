using UnityEngine;
using UnityEngine.UI;
public class PickUpItem : MonoBehaviour, IInteractable
{
    public string displaySprite;
    public enum Property {Usable, Displayable};

    public string displayImage;

    public string combinationItem;

    public Property itemProperty;
    
    private GameObject _inventorySlots;
    
    

    public void Interact(DisplayImage currentDisplay)
    {
        ItemPickUp();
    }

    public void ItemPickUp()
    {
        _inventorySlots = GameObject.Find("Slots");
        foreach (Transform slot in _inventorySlots.transform)
        {
            
            //если первый слот пуст, кладем туда айтем
            if (slot.transform.GetChild(0).GetComponent<Image>().sprite.name == "empty_item")
            {
                slot.transform.GetChild(0).GetComponent<Image>().sprite =
                Resources.Load<Sprite>("Inventory Items/"+ displaySprite);
                slot.GetComponent<Slot>().AssignProperty((int)itemProperty, displayImage, combinationItem);
                Destroy(gameObject);
                break;
            }
        }
        
    }

    
}
