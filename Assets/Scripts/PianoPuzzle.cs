using System.Collections.Generic;
using UnityEngine;

public class PianoPuzzle : MonoBehaviour
{
    public AudioSource[] keySounds;
    public GameObject hiddenObject;
    public string correctSequenceString;

    [SerializeField] private List<int> currentInput; // текущий ввод
    [HideInInspector] public List<int> correctSequence; // расчитанная последовательность

    public string currentSequence;

    private void Awake()
    {
        ParseSequence(); // при запуске преобразуем строку в список чисел
    }

    private void Update()
    {
        currentSequence = string.Join("", currentInput);
    }

    public void PressKey(int keyIndex) // keyIndex от 1 до 5
    {
        PlayKeySound(keyIndex - 1);
        currentInput.Add(keyIndex);

        for (int i = 0; i < currentInput.Count; i++)
        {
            if (i >= correctSequence.Count || currentInput[i] != correctSequence[i])
            {
                ResetInput();
                return;
            }
        }

        if (currentInput.Count == correctSequence.Count)
        {
            Debug.Log("Правильная последовательность!");
            hiddenObject.SetActive(true);
        }
    }

    private void PlayKeySound(int index)
    {
        if (index >= 0 && index < keySounds.Length)
        {
            keySounds[index].Play();
        }
    }

    private void ResetInput()
    {
        currentInput.Clear();
    }

    private void ParseSequence()
    {
        correctSequence.Clear();
        foreach (char c in correctSequenceString)
        {
            if (char.IsDigit(c))
            {
                correctSequence.Add(int.Parse(c.ToString()));
            }
        }
    }

    private void OnValidate()
    {
        ParseSequence();
    }
}
