using Unity.VisualScripting;
using UnityEngine;

public class LockerNumber : MonoBehaviour, IInteractable
{
    [SerializeField] private AudioClip digits;
    public void Interact(DisplayImage currentDisplay)
    {
        transform.parent.GetComponent<NumberLock>().currentIndividualIndex[transform.GetSiblingIndex()]++;
        SoundManager.instance.PlaySound(digits);

        if (transform.parent.GetComponent<NumberLock>().currentIndividualIndex[transform.GetSiblingIndex()] > 9)
        {
            transform.parent.GetComponent<NumberLock>().currentIndividualIndex[transform.GetSiblingIndex()] = 0;
        }
        
        this.GameObject().GetComponent<SpriteRenderer>().sprite = 
            transform.parent.GetComponent<NumberLock>().numbersSprites[transform.parent.GetComponent<NumberLock>()
                .currentIndividualIndex[transform.GetSiblingIndex()]];
        
    }
}
