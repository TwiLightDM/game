using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Drawer : MonoBehaviour, IInteractable
{
    public string unlockItem;
    private GameObject _inventory;
    private bool _isUnlocked = false; // Флаг, что комод разблокирован
    private bool _keyUsed = false; // Флаг, что ключ был использован
    private ChangeView _changeView; // Ссылка на компонент ChangeView

    void Start()
    {
        _inventory = GameObject.Find("Inventory");
        _changeView = GetComponentInChildren<ChangeView>(); // Получаем компонент ChangeView
    }

    public void Interact(DisplayImage currentDisplay)
    {
        // Если комод уже разблокирован, просто переключаем вид
        if (_isUnlocked)
        {
            _changeView?.Interact(currentDisplay);
            return;
        }

        // Если ключ уже использован, но комод еще не открыт
        if (_keyUsed)
        {
            _isUnlocked = true;
            _changeView?.Interact(currentDisplay);
            return;
        }

        // Проверяем, есть ли нужный ключ
        if (_inventory.GetComponent<Inventory>().CurrentSelectedSlot != null && 
            _inventory.GetComponent<Inventory>().CurrentSelectedSlot.gameObject.transform.GetChild(0)
                .GetComponent<Image>().sprite.name == unlockItem)
        {
            Debug.Log("Ключ использован! Теперь можно открыть комод");
            _keyUsed = true;
            _inventory.GetComponent<Inventory>().CurrentSelectedSlot.GetComponent<Slot>().ClearSlot();
            
            // Не открываем комод сразу, только отмечаем, что ключ использован
        }
        else
        {
            Debug.Log("Нужен ключ для открытия комода!");
        }
    }
}
// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.UI;
// public class Drawer : MonoBehaviour, IInteractable
// {
//     public string unlockItem;
//     private GameObject _inventory;
//
//     void Start()
//     {
//         _inventory = GameObject.Find("Inventory");
//     }
//
//     public void Interact(DisplayImage currentDisplay)
//     {
//         if (_inventory.GetComponent<Inventory>().CurrentSelectedSlot.gameObject.transform.GetChild(0)
//                 .GetComponent<Image>().sprite.name == unlockItem)
//         {
//             Debug.Log("unlock");
//             
//             _inventory.GetComponent<Inventory>().CurrentSelectedSlot.GetComponent<Slot>().ClearSlot();
//         }
//     }
// }
//
// // _inventory.GetComponent<Inventory>().CurrentSelectedSlot.GetComponent<Slot>().ItemProperty =
// //     Slot.Property.Empty;
// // _inventory.GetComponent<Inventory>().CurrentSelectedSlot.gameObject.transform.GetChild(0)
// //     .GetComponent<Image>().sprite = Resources.Load<Sprite>("Inventory Items/empty_item");
