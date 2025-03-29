using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Slot : MonoBehaviour, IPointerClickHandler
{
    private GameObject _inventory;
    public enum Property { Usable, Displayable, Empty };
    public Property ItemProperty { get; set; }

    private string _displayImage;
    
    public string CombinationItem { get; private set; }

    void Start()
    {
        _inventory = GameObject.Find("Inventory");
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (_inventory == null) return;

        Inventory inventory = _inventory.GetComponent<Inventory>();
        if (inventory == null) return;

        // Сохраняем предыдущий выбранный слот
        inventory.PreviousSelectedSlot = inventory.CurrentSelectedSlot;
        inventory.CurrentSelectedSlot = this.gameObject;

        // Проверяем, что предыдущий слот существует и не пустой
        if (inventory.PreviousSelectedSlot != null && 
            inventory.PreviousSelectedSlot.GetComponent<Slot>() != null)
        {
            Combine();
        }

        if (ItemProperty == Property.Displayable) 
        {
            DisplayItem();
        }
    }

    public void AssignProperty(int orderNumber, string displayImage, string combinationItem)
    {
        ItemProperty = (Property)orderNumber;
        _displayImage = displayImage;
        CombinationItem = combinationItem;
    }

    public void DisplayItem()
    {
        if (string.IsNullOrEmpty(_displayImage)) return;

        Inventory inventory = _inventory.GetComponent<Inventory>();
        if (inventory == null || inventory.itemDisplayer == null) return;

        inventory.itemDisplayer.SetActive(true);
        inventory.itemDisplayer.GetComponent<Image>().sprite = 
            Resources.Load<Sprite>("Inventory Items/" + _displayImage);
    }

    void Combine()
    {
        Inventory inventory = _inventory.GetComponent<Inventory>();
        if (inventory == null || inventory.PreviousSelectedSlot == null) return;

        Slot previousSlot = inventory.PreviousSelectedSlot.GetComponent<Slot>();
        Slot currentSlot = GetComponent<Slot>();

        // Проверяем, что оба слота содержат предметы для комбинации
        if (previousSlot == null || currentSlot == null) return;
        if (previousSlot.ItemProperty == Property.Empty || currentSlot.ItemProperty == Property.Empty) return;
        if (string.IsNullOrEmpty(previousSlot.CombinationItem) || string.IsNullOrEmpty(currentSlot.CombinationItem)) return;

        if (previousSlot.CombinationItem == currentSlot.CombinationItem)
        {
            GameObject combinedPrefab = Resources.Load<GameObject>("Combined Items/" + CombinationItem);
            if (combinedPrefab != null)
            {
                GameObject combinedItem = Instantiate(combinedPrefab);
                if (combinedItem.TryGetComponent(out PickUpItem pickUpItem))
                {
                    pickUpItem.ItemPickUp();
                }

                previousSlot.ClearSlot();
                currentSlot.ClearSlot();
            }
            else
            {
                Debug.LogWarning("Failed to load combined item: " + CombinationItem);
            }
        }
    }

    public void ClearSlot()
    {
        ItemProperty = Property.Empty;
        _displayImage = "";
        CombinationItem = "";
        
        Image slotImage = transform.GetChild(0).GetComponent<Image>();
        if (slotImage != null)
        {
            slotImage.sprite = Resources.Load<Sprite>("Inventory Items/empty_item");
        }
    }
}