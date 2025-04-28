using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class houseHistory : MonoBehaviour
{
    [SerializeField]private GameObject historyUI;
    [SerializeField]private GameObject room1;
    [SerializeField] private AudioClip sound;
    [SerializeField] private AudioClip apperSound;
    
    [SerializeField] private AudioClip houseTheme;
    private float checkDelay = 25f; // Задержка перед повторным включением
    private float timer = 0f;
    private bool isThemePlaying = false;
    void Start()
    {
        SoundManager.instance.PlaySound(apperSound); 
    }

    // Update is called once per frame
    private void Update()
    {
        // Если музыка должна играть, но её остановили
        if (isThemePlaying && !SoundManager.instance.IsClipPlaying(houseTheme))
        {
            timer += Time.deltaTime; // Начинаем отсчёт задержки

            // Если прошло 40 секунд, включаем снова
            if (timer >= checkDelay)
            {
                SoundManager.instance.PlayLoop(houseTheme);
                timer = 0f; // Сбрасываем таймер
            }
        }
        // Если музыка играет, сбрасываем таймер (чтобы задержка считалась только после остановки)
        else if (SoundManager.instance.IsClipPlaying(houseTheme))
        {
            timer = 0f;
        }
    }
    public void Resume()
    {
        historyUI.SetActive(false);
        SetLayerRecursively(room1, LayerMask.NameToLayer("Default"));
        SoundManager.instance.PlaySound(sound);
        SoundManager.instance.PlayLoop(houseTheme);
        isThemePlaying = true;
       
    }
    private void SetLayerRecursively(GameObject obj, int newLayer)
    {
        if (obj == null) return;
        
        obj.layer = newLayer;
        
        foreach (Transform child in obj.transform)
        {
            if (child != null)
            {
                SetLayerRecursively(child.gameObject, newLayer);
            }
        }
    }
}
