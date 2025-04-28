using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour
{
    [SerializeField] private AudioClip buttonClickSound;
    void Start()
    {
        
    }

    public void OpenHouse1()
    {
        SceneManager.LoadScene("HouseOne");
        SoundManager.instance.PlaySound(buttonClickSound);
    }
    public void OpenHouse2()
    {
        SceneManager.LoadScene("HouseTwo");
        SoundManager.instance.PlaySound(buttonClickSound);
    }
    public void OpenHouse3()
    {
        SceneManager.LoadScene("HouseThree");
        SoundManager.instance.PlaySound(buttonClickSound);
    }
    public void OpenMenu()
    {
        SceneManager.LoadScene("Menu");
        SoundManager.instance.PlaySound(buttonClickSound);
    }
}
