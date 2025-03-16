using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsManage : MonoBehaviour
{
    private DisplayImage _currentDisplay;
    public GameObject[] objectsToManage;

    void Start()
    {
        _currentDisplay = GameObject.Find("displayImage").GetComponent<DisplayImage>();
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
}
