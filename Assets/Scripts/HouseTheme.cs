using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseTheme : MonoBehaviour
{
    [SerializeField] private AudioClip houseTheme;
    private float checkDelay = 40f; // Задержка перед повторным включением
    private float timer = 0f;
    private bool isThemePlaying = false;

    private void Start()
    {
        
        // Включаем музыку сразу при старте
        SoundManager.instance.PlayLoop(houseTheme);
        isThemePlaying = true;
    }

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
}
