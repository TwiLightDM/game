using Unity.VisualScripting;
using UnityEngine;

public class NumberLock : MonoBehaviour
{
    public string password;
    public GameObject openLockerSprite;
    private GameObject displayImage;
    
    [HideInInspector]
    public Sprite[] numbersSprites;
    [HideInInspector]
    public int[] currentIndividualIndex = { 0, 0, 0, 0};
    
    private bool _isOpen;
    private void Start()
    {
        displayImage = GameObject.Find("displayImage");
        openLockerSprite.SetActive(false);
        _isOpen = false;
        LoadAllNumbersSprites();
    }

    private void Update()
    {
        OpenLocker();
    }
    
    void LoadAllNumbersSprites()
    {
        numbersSprites = Resources.LoadAll<Sprite>("Sprites/numbers");
    }

    bool verifyPassword()
    {
        for (int i = 0; i < currentIndividualIndex.Length; i++)
        {
            if (password[i] != transform.GetChild(i).GetComponent<SpriteRenderer>().sprite.name
                    .Substring(transform.GetChild(i).GetComponent<SpriteRenderer>().sprite.name.Length - 1)[0])
            {
                return false;
            }
        }
        return true;
    }

    void OpenLocker()
    {
        if (_isOpen) return;
        if (verifyPassword())
        {
            _isOpen = true;
            openLockerSprite.SetActive(true);

            for (int i = 0; i < currentIndividualIndex.Length; i++)
            {
                Destroy(transform.GetChild(i).gameObject);
            }
        }
    }

    void layerManager()
    {
        if(_isOpen) return;
        if (displayImage.GetComponent<DisplayImage>().CurrentState == DisplayImage.State.Normal)
        {
            foreach (Transform child in transform)
            {
                child.GameObject().layer = 2;
            }
        }
        else
        {
            foreach (Transform child in transform)
            {
                child.GameObject().layer = 0;
            }
        }
    }
        
}
