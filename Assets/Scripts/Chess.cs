using UnityEngine;
using UnityEngine.UI;
using TMPro; 
using UnityEngine.EventSystems;
public class Chess : MonoBehaviour, IPointerClickHandler
{
    public GameObject screenPanel;
    public string correctPassword;

    private string _inputPassword;
    
    private bool _isCorrectPassword = false;

    public GameObject obtainItem;
    
    private GameObject _displayImage;
    [SerializeField] private AudioClip openDoorSound;
    
    void Start()
    {
        
        _displayImage= GameObject.Find("displayImage");
        obtainItem.SetActive(false);
        screenPanel.SetActive(false);
        this.gameObject.SetActive(false);
        
    }

    void Update()
    {
        VerifyPassword();
        HideDisplay();
    }
    void VerifyPassword()
    {
        if (_isCorrectPassword == true)
        {
            return;
        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            _inputPassword = screenPanel.transform.Find("Text Area/Text").GetComponent<TextMeshProUGUI>().text.Replace("\u200B", "").Trim();

           
            
            Debug.Log($"Input: '{_inputPassword}' (Length: {_inputPassword.Length})");
            Debug.Log($"Correct: '{correctPassword}' (Length: {correctPassword.Length})");
            
            if (_inputPassword == correctPassword)
            {
                _isCorrectPassword = true;
                Destroy(GameObject.Find("ScreenActivator"));
                Destroy(screenPanel);
                Debug.Log("Password Correct");
                GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/chess_solved");
                SoundManager.instance.PlaySound(openDoorSound);
                obtainItem.SetActive(true);
            }
        }
    }

    void HideDisplay()
    {
        if (Input.GetMouseButtonDown(0) && !UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
        {
            this.gameObject.SetActive(false);
        }

        if (_displayImage.GetComponent<DisplayImage>().CurrentState == DisplayImage.State.Normal)
        {
            this.gameObject.SetActive(false);
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        screenPanel.SetActive(false);
    }
}
