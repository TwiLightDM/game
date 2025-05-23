using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class ExitDoor : MonoBehaviour, IInteractable
{
    public GameObject changedStateSprite;
    public string unlockItem;
    public GameObject escapeMessage;
    [SerializeField] private AudioClip openDoorSoundSound;
    [SerializeField] private AudioClip lockedDoorSound;
    private GameObject _inventory;
    
    void Start()
    {
        changedStateSprite.SetActive(false);
        _inventory = GameObject.Find("Inventory");
    }
    
    public void Interact(DisplayImage currentDisplay)
    {
        if (_inventory.GetComponent<Inventory>().CurrentSelectedSlot.gameObject.transform.GetChild(0)
                .GetComponent<Image>().sprite.name==unlockItem|| unlockItem=="")
        {
            SoundManager.instance.PlaySound(openDoorSoundSound);
            changedStateSprite.SetActive(true);
            gameObject.layer = 2;
            
            Instantiate(escapeMessage, GameObject.Find("Canvas").transform);

            StartCoroutine(LoadMenu());
            
            string currentScene = SceneManager.GetActiveScene().name;
            if (currentScene == "HouseOne") PlayerPrefs.SetInt("Level2Unlocked", 1);
            else if (currentScene == "HouseTwo") PlayerPrefs.SetInt("Level3Unlocked", 1);
        }
        else{
           SoundManager.instance.PlaySound(lockedDoorSound);
        }
    }

    public IEnumerator LoadMenu()
    {
        yield return new WaitForSeconds(4);
        SceneManager.LoadScene("Menu");
    }
}
