using UnityEngine;

public class PianoKey: MonoBehaviour, IInteractable
{
    public int keyIndex;
    public AudioClip keySound;
    public PianoPuzzle pianoPuzzle;

    public void Interact(DisplayImage currentDisplay)
    {
        if (keySound != null)
            SoundManager.instance.PlaySound(keySound);

        if (pianoPuzzle != null)
            pianoPuzzle.PressKey(keyIndex);
    }
}