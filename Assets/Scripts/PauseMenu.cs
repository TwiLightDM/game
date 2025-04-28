using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour
{
    public static bool gamePaused = false;
    public GameObject pauseMenuUI;

    [SerializeField] private AudioClip buttons;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gamePaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        SoundManager.instance.PlaySound(buttons);
        gamePaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        
        gamePaused = true;
    }

    public void LoadMenu()
    {
        SoundManager.instance.PlaySound(buttons);
        SceneManager.LoadScene("Menu");
    }
}
