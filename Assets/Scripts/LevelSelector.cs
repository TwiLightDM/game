using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour
{
    [SerializeField] private AudioClip buttonClickSound;
    public bool debug;
    
    private void Start()
    {
        if (!PlayerPrefs.HasKey("Level2Unlocked")) PlayerPrefs.SetInt("Level2Unlocked", 0);
        if (!PlayerPrefs.HasKey("Level3Unlocked")) PlayerPrefs.SetInt("Level3Unlocked", 0);
    }
    
    public void OpenHouse1()
    {
        SceneManager.LoadScene("HouseOne");
        SoundManager.instance.PlaySound(buttonClickSound);
    }
    public void OpenHouse2()
    {
        if (debug || PlayerPrefs.GetInt("Level2Unlocked") == 1)
        {
            SceneManager.LoadScene("HouseTwo");
            SoundManager.instance.PlaySound(buttonClickSound);
        }
        SoundManager.instance.PlaySound(buttonClickSound);
    }
    public void OpenHouse3()
    {
        if (debug || PlayerPrefs.GetInt("Level3Unlocked") == 1)
        {
            SceneManager.LoadScene("HouseThree");
            SoundManager.instance.PlaySound(buttonClickSound);
        }
        SoundManager.instance.PlaySound(buttonClickSound);
    }
    public void OpenMenu()
    {
        SceneManager.LoadScene("Menu");
        SoundManager.instance.PlaySound(buttonClickSound);
    }
}
