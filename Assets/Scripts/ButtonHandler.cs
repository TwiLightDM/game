using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonHandler : MonoBehaviour
{
    private DisplayImage _currentDisplay;
    private float _initialCameraSize;
    private Vector3 _initialCameraPosition;
    [SerializeField] private AudioClip buttonClickSound;
    [SerializeField] private AudioClip menuMusic;
    [SerializeField] private AudioClip footstepSound;
    public string spriteName;
    void Start()
    {
        SoundManager.instance.PlaySound(menuMusic);
        _currentDisplay = GameObject.Find("displayImage").GetComponent<DisplayImage>();
        if (Camera.main == null) return;
        _initialCameraSize = Camera.main.orthographicSize;
        _initialCameraPosition = Camera.main.transform.position;
    }

    public void OnRightClick()
    {
        
        
        _currentDisplay.CurrentRoom++;
        SoundManager.instance.PlaySound(footstepSound);
       
    }

    public void OnLeftClick()
    {
        SoundManager.instance.PlaySound(footstepSound);
       
        _currentDisplay.CurrentRoom--;
    }

    public void OnReturnClick()
    {
        if (_currentDisplay.CurrentState == DisplayImage.State.Zoom)
        {
            SoundManager.instance.PlaySound(footstepSound);
            GameObject.Find("displayImage").GetComponent<DisplayImage>().CurrentState = DisplayImage.State.Normal;
            ZoomInObject[] zoomInObjects = FindObjectsOfType<ZoomInObject>();
            
            foreach (var zoomInObject in zoomInObjects)
            {
                zoomInObject.gameObject.layer = 0;
            }
            if (Camera.main == null) return;
            Camera.main.orthographicSize = _initialCameraSize;
            Camera.main.transform.position = _initialCameraPosition;
        }
        else
        {
            SoundManager.instance.PlaySound(footstepSound);
           
            _currentDisplay.GetComponent<SpriteRenderer>().sprite =
                // Resources.Load<Sprite>("Sprites/room" + _currentDisplay.CurrentRoom);
                Resources.Load<Sprite>(spriteName + _currentDisplay.CurrentRoom);
            _currentDisplay.CurrentState = DisplayImage.State.Normal;
        }
    }

    public void OnPlayClick()
    {
         SoundManager.instance.PlaySound(buttonClickSound);
         SceneManager.LoadScene("Levels");
    }
    
    public void OnExitClick()
    {
        SoundManager.instance.PlaySound(buttonClickSound);
        Application.Quit();
    }
}