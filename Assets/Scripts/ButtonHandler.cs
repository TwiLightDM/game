using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHandler : MonoBehaviour
{
    private DisplayImage _currentDisplay;
    private float _initialCameraSize;
    private Vector3 _initialCameraPosition;

    void Start()
    {
        _currentDisplay = GameObject.Find("displayImage").GetComponent<DisplayImage>();
        _initialCameraSize = Camera.main.orthographicSize;
        _initialCameraPosition = Camera.main.transform.position;
    }

    public void OnRightClick()
    {
        _currentDisplay.CurrentRoom++;
    }

    public void OnLeftClick()
    {
        _currentDisplay.CurrentRoom--;
    }

    public void OnReturnClick()
    {
        if (_currentDisplay.CurrentState == DisplayImage.State.Zoom)
        {
            GameObject.Find("displayImage").GetComponent<DisplayImage>().CurrentState = DisplayImage.State.Normal;
            ZoomInObject[] zoomInObjects = FindObjectsOfType<ZoomInObject>();

            foreach (var zoomInObject in zoomInObjects)
            {
                zoomInObject.gameObject.layer = 0;
            }

            Camera.main.orthographicSize = _initialCameraSize;
            Camera.main.transform.position = _initialCameraPosition;
        }
        else
        {
            _currentDisplay.GetComponent<SpriteRenderer>().sprite =
                Resources.Load<Sprite>("Sprites/room" + _currentDisplay.CurrentRoom);
            _currentDisplay.CurrentState = DisplayImage.State.Normal;
        }
    }
}