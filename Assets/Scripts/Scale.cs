using UnityEngine;

public class Scale : MonoBehaviour
{
    public GameObject[] scaleBoxes;
    public GameObject scaleDisplayer;
    public bool isArmor;
    private GameObject _displayImage;
    private Block[] _blocks;

    public bool isSolved { get; private set; }

    void Awake()
    {
        isSolved = false;
        _displayImage = GameObject.Find("displayImage");
        _blocks = FindObjectsOfType<Block>();
    }

    void Update()
    {
        Display();
        if (VerifySolution() && !isSolved)
        {
            isSolved = true;
            if (isArmor)
            {
                scaleDisplayer.GetComponent<ChangeView>().spriteName = "armor solved";
                _displayImage.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/armor solved");
            }
            else
            {
                scaleDisplayer.GetComponent<ChangeView>().spriteName = "scale solved";
                _displayImage.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/scale solved");
            }
        }
    }

    void Display()
    {
        if (_displayImage.GetComponent<SpriteRenderer>().sprite.name == "scale" || _displayImage.GetComponent<SpriteRenderer>().sprite.name == "scale solved" || _displayImage.GetComponent<SpriteRenderer>().sprite.name == "armor" || _displayImage.GetComponent<SpriteRenderer>().sprite.name == "armor solved")
        {
            foreach (Block block in _blocks)
            {
                block.gameObject.SetActive(true);
            }
        }
        else
        {
            foreach (Block block in _blocks)
            {
                block.gameObject.SetActive(false);
            }
        }
    }

    bool VerifySolution()
    {
        for (int i = 0; i < scaleBoxes.Length; i++)
        {
            if (_blocks[i].indexOfBox != _blocks[i].correctBoxIndex)
            {
                return false;
            }
        }

        return true;
    }
}