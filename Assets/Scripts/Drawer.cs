using UnityEngine;
using UnityEngine.UI;


public class Drawer : MonoBehaviour, IInteractable
{
    public string unlockItem;
    private GameObject _inventory;
    public bool isPiano;
    public bool isThrone;
    public GameObject throneView;
    private bool _isUnlocked = false; // Флаг, что комод разблокирован
    private bool _keyUsed = false; // Флаг, что ключ был использован
    private ChangeView _changeView; // Ссылка на компонент ChangeView
    [SerializeField] private AudioClip lockedCabinetSound;
    [SerializeField] private AudioClip keySound;
    public GameObject[] keys;
    
    void Start()
    {
        gameObject.layer = 1;
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

        // Если ключ уже использован
        if (_keyUsed)
        {
            _isUnlocked = true;
            return;
        }

        // Проверяем, есть ли нужный ключ
        if (_inventory.GetComponent<Inventory>().CurrentSelectedSlot != null && 
            _inventory.GetComponent<Inventory>().CurrentSelectedSlot.gameObject.transform.GetChild(0)
                .GetComponent<Image>().sprite.name == unlockItem)
        {
            SoundManager.instance.PlaySound(keySound);
            Debug.Log("Ключ использован! Теперь можно открыть комод");
            _keyUsed = true;
            _inventory.GetComponent<Inventory>().CurrentSelectedSlot.GetComponent<Slot>().ClearSlot();
            if (isPiano)
            {
                foreach (GameObject key in keys)
                {
                    key.SetActive(true);
                }
            }

            if (isThrone)
            {
                throneView.SetActive(true);
            }
            
            // Не открываем комод сразу, только отмечаем, что ключ использован
        }
        else
        {
            SoundManager.instance.PlaySound(lockedCabinetSound);
            Debug.Log("Нужен ключ для открытия комода!");
        }
    }
}
