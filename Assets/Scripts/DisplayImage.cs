using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayImage : MonoBehaviour
{
    public enum State
    {
        Normal,
        Zoom,
        ChangedView
    };

    public State CurrentState { get; set; }

    public int CurrentRoom
    {
        get { return _currentRoom; }
        set
        {
            if (value == 5)
            {
                _currentRoom = 1;
            }
            else if (value == 0)
            {
                _currentRoom = 4;
            }
            else
            {
                _currentRoom = value;
            }
        }
    }

    private int _currentRoom;
    private int _previousRoom;

    void Start()
    {
        _previousRoom = 0;
        CurrentRoom = 1;
    }

    void Update()
    {
        if (_currentRoom != _previousRoom)
        {
            GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/room" + _currentRoom.ToString());
        }

        _previousRoom = _currentRoom;
    }
}