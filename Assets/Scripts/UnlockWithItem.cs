using UnityEngine;
using UnityEngine.UI;

public class UnlockWithItem : MonoBehaviour, IInteractable
{
    public string unlockItem; // Имя предмета, который разблокирует объект
    public GameObject openLockerSprite; // Объект, который будет активирован
    private GameObject _inventory;

    [SerializeField] private AudioClip lockedSound;
    [SerializeField] private AudioClip unlockSound;
    [SerializeField] private AudioClip openSound;
    [SerializeField] private string message;
    private bool _isUnlocked = false;

    void Start()
    {
        _inventory = GameObject.Find("Inventory");
        if (openLockerSprite != null)
        {
            openLockerSprite.SetActive(false);
        }
    }

    public void Interact(DisplayImage currentDisplay)
    {
        if (_isUnlocked)
        {
            ActivateLocker();
            return;
        }

        // Проверяем, есть ли нужный предмет в инвентаре
        if (_inventory.GetComponent<Inventory>().CurrentSelectedSlot != null && 
            _inventory.GetComponent<Inventory>().CurrentSelectedSlot.gameObject.transform.GetChild(0)
                .GetComponent<Image>().sprite.name == unlockItem)
        {
            SoundManager.instance.PlaySound(unlockSound);
            _inventory.GetComponent<Inventory>().CurrentSelectedSlot.GetComponent<Slot>().ClearSlot();
            _isUnlocked = true;
            ActivateLocker();
        }
        else
        {
            tipsManager.displayTipEvent?.Invoke(message);
            Debug.Log("Нужен предмет: " + unlockItem);
        }
    }

    private void ActivateLocker()
    {
        if (openLockerSprite != null)
        {
            openLockerSprite.SetActive(true);
            SoundManager.instance.PlaySound(openSound);
        }
    }

   
}