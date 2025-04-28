using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static  SoundManager instance { get; private set; }
    private AudioSource source;

    private void Awake()
    {
        instance = this;
        source = GetComponent<AudioSource>();
        
    }

    public void PlaySound(AudioClip clip)
    {
        source.PlayOneShot(clip);
    }
    
    // Для зацикленных звуков (музыка)
    public void PlayLoop(AudioClip clip)
    {
        if (source.clip == clip && source.isPlaying) 
            return; // Если тот же клип уже играет, не перезапускаем
        
        source.clip = clip;
        source.loop = true; // На всякий случай принудительно включаем Loop
        source.Play();
    }
    public void StopLoop()
    {
        source.Stop();
        source.clip = null;
    }
       public void StopSound()
    {
        source.Stop();
        source.clip = null;
    }

     public bool IsClipPlaying(AudioClip clip)
    {
        return source.clip == clip && source.isPlaying;
    }
   
}
