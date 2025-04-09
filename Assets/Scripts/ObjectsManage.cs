using UnityEngine;

public class ObjectsManage : MonoBehaviour
{
    private DisplayImage _currentDisplay;
    public GameObject[] objectsToManage;
    public GameObject[] UIRenderObjects;
    void Start()
    {
        _currentDisplay = GameObject.Find("displayImage").GetComponent<DisplayImage>();
        RenderUI();
    }

    void Update()
    {
        ManageObjects();
    }
    
    void ManageObjects()
    {
        foreach (GameObject objectToManage in objectsToManage)
        {
            if (objectToManage.name == _currentDisplay.GetComponent<SpriteRenderer>().sprite.name)
            {
                objectToManage.SetActive(true);
            }
            else
            {
                objectToManage.SetActive(false);
            }
        }
    }
    
    void RenderUI()
    {
        for (int i = 0; i < UIRenderObjects.Length; i++)
        {
            UIRenderObjects[i].SetActive(false);
        }
    }
}

