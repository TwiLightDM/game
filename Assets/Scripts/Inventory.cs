using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public GameObject CurrentSelectedSlot { get; set; }
    public GameObject PreviousSelectedSlot { get; set; }
    public Slot CurrentDraggedSlot { get; set; }
    private GameObject _slots;
    public GameObject itemDisplayer { get; private set; }

    void Start()
    {
        InitializeInventory();
        _slots = GameObject.Find("Slots");
        
    }

    void Update()
    {
        SelectSlot();
        HideDisplay();
    }

    void InitializeInventory()
    {
        var slots = GameObject.Find("Slots");
        itemDisplayer = GameObject.Find("ItemDisplayer");
        itemDisplayer.SetActive(false);
        foreach (Transform slot in slots.transform)
        {
            // Устанавливаем спрайт "empty_item" для первого дочернего объекта
            slot.transform.GetChild(0).GetComponent<Image>().sprite =
                Resources.Load<Sprite>("Inventory Items/empty_item");
            slot.GetComponent<Slot>().ItemProperty = Slot.Property.Empty;
        }
        CurrentSelectedSlot = GameObject.Find("slot");
        PreviousSelectedSlot = CurrentSelectedSlot;
    }

    void SelectSlot()
    {
        foreach (Transform slot in _slots.transform)
        {
            // Получаем компонент Image слота
            Image slotImage = slot.GetComponent<Image>();

            // Проверяем, выбран ли текущий слот и является ли он Usable
            if (slot.gameObject == CurrentSelectedSlot && slot.GetComponent<Slot>().ItemProperty == Slot.Property.Usable
            ||slot.gameObject == CurrentSelectedSlot && slot.GetComponent<Slot>().ItemProperty == Slot.Property.SeeAndClick)
            {
                // Устанавливаем цвет выделения
                slotImage.color = new Color(0.9f, 0.1f, 0.6f, 1f);
            }
            else if (slot.gameObject == CurrentSelectedSlot && slot.GetComponent<Slot>().ItemProperty == Slot.Property.Displayable)
            {
                // slot.GetComponent<Slot>().DisplayItem();
            }
            else
            {
                // Сбрасываем цвет
                slotImage.color = new Color(1, 1, 1, 1);
            }
        }
    }

    void HideDisplay()
    {
        if (Input.GetMouseButtonDown(0)&& !UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
        {
            itemDisplayer.SetActive(false);
            if (CurrentSelectedSlot.GetComponent<Slot>().ItemProperty == Slot.Property.Displayable)
            {
                CurrentSelectedSlot = PreviousSelectedSlot;
                PreviousSelectedSlot = CurrentSelectedSlot;
            }
        }
    }
}
