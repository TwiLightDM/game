using UnityEngine;

public class CrownScale : MonoBehaviour
{
    public GameObject[] scaleBoxes;
    private GameObject _displayImage;
    private Crown[] _crowns;
    public GameObject hiddenObject;
    public AudioClip soundOfThron;

    public bool isSolved { get; private set; }

    void Awake()
    {
        isSolved = false;
        _displayImage = GameObject.Find("displayImage");
        _crowns = FindObjectsOfType<Crown>();
    }

    void Update()
    {
        Display();
        if (VerifySolution() && !isSolved)
        {
            isSolved = true;
            SoundManager.instance.PlaySound(soundOfThron);
            hiddenObject.SetActive(true);
        }
    }

    void Display()
    {
        if (_displayImage.GetComponent<SpriteRenderer>().sprite.name == "pedestal")
        {
            foreach (Crown crown in _crowns)
            {
                crown.gameObject.SetActive(true);
            }
        }else
        {
            foreach (Crown crown in _crowns)
            {
                crown.gameObject.SetActive(false);
            }
        }
    }

    bool VerifySolution()
    {
        for (int i = 0; i < scaleBoxes.Length; i++)
        {
            if (_crowns[i].indexOfBox != _crowns[i].correctBoxIndex)
            {
                return false;
            }
        }

        return true;
    }
}