using UnityEngine;
using UnityEngine.UI;

public class DynamicObject : MonoBehaviour, IInteractable
{
    public string unlockItem;
    public GameObject changedStateSprite;
    private GameObject _inventory;
    [SerializeField] private AudioClip sound;
    

    void Start()
    {
        changedStateSprite.SetActive(false);
        _inventory = GameObject.Find("Inventory");
       
    }
    

    public void Interact(DisplayImage currentDisplay)
    {
        if (_inventory.GetComponent<Inventory>().CurrentSelectedSlot.gameObject.transform.GetChild(0).GetComponent<Image>().sprite.name==unlockItem|| unlockItem=="")
        {
            SoundManager.instance.PlaySound(sound);
            changedStateSprite.SetActive(true);
           // _inventory.GetComponent<Inventory>().CurrentSelectedSlot.GetComponent<Slot>().ClearSlot();
            
        }
    }
}
