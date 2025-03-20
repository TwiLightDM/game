using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Slot : MonoBehaviour, IPointerClickHandler
{
    private GameObject _inventory;
    public enum Property { Usable, Displayable, Empty };
    public Property ItemProperty { get;  set; }

    private string _displayImage;
    
    public string CombinationItem { get;  private set; }
    void Start()
    {
        _inventory = GameObject.Find("Inventory");
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        // Получаем компонент Inventory
        Inventory inventory = _inventory.GetComponent<Inventory>();

        // Устанавливаем CurrentSelectedSlot на родительский объект (slot)
        inventory.PreviousSelectedSlot = inventory.CurrentSelectedSlot;
        inventory.CurrentSelectedSlot = this.gameObject;
        Combine();
        if(ItemProperty == Slot.Property.Displayable) DisplayItem();
        
    }

    public void AssignProperty(int orderNumber, string displayImage,string combinationItem)
    {
        // Устанавливаем свойство предмета
        ItemProperty = (Property)orderNumber;
        this._displayImage = displayImage;
        this.CombinationItem = combinationItem;
    }

    public void DisplayItem()
    {
        _inventory.GetComponent<Inventory>().itemDisplayer.SetActive(true);
        
        _inventory.GetComponent<Inventory>().itemDisplayer.GetComponent<Image>().sprite =
            Resources.Load<Sprite>("Inventory Items/" + _displayImage);
    }

    void Combine()
    {
        if (_inventory.GetComponent<Inventory>().PreviousSelectedSlot.GetComponent<Slot>().CombinationItem ==
            this.gameObject.GetComponent<Slot>().CombinationItem && this.gameObject.GetComponent<Slot>().CombinationItem!="")
        {
            Debug.Log("combine");
            var combinedItem = Instantiate(Resources.Load<GameObject>("Combined Items/" + CombinationItem));
            combinedItem.GetComponent<PickUpItem>().ItemPickUp();
            
            _inventory.GetComponent<Inventory>().PreviousSelectedSlot.GetComponent<Slot>().ClearSlot();
            ClearSlot();
        }
    }
    public void ClearSlot()
    {
        ItemProperty = Slot.Property.Empty;
        _displayImage = "";
        CombinationItem = "";
        transform.GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>("Inventory Items/empty_item");
    }
}