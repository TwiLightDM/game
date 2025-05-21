// using System;
// using System.Collections;
// using System.Collections.Generic;
// using TMPro;
// using UnityEngine;
//
// public class tipsManager : MonoBehaviour
// {
//     public static Action<string> displayTipEvent;
//     public static Action disableTipEvent;
//     [SerializeField] private TMP_Text messageText;
//     private int longMessageLength = 20;
//     private Animator anim;
//     private int activeTips;
//     private float shortDelay = 3f; 
//     private float longDelay = 5f;
//     private float timer = 0f;
//     private bool isTipActive = false;
//     void Start()
//     {
//        
//         anim = GetComponent<Animator>();
//         
//     }
// 	private void Update()
//     {
//         if (isTipActive)
//         {
//             timer += Time.deltaTime;
//             float currentDelay = messageText.text.Length >= longMessageLength ? longDelay : shortDelay;
//             if (timer >= currentDelay)
//             {
//                 tipsManager.disableTipEvent?.Invoke();
//                 isTipActive = false;
//                 timer = 0f;
//             }
//         }
//     }
//     // Update is called once per frame
//     void displayTip(string message)
//     {
//      
//         messageText.text = message;
//        
//         anim.SetInteger("state", ++activeTips);
//         
//         isTipActive = true;
//     }
//
//     void disableTip()
//     {
//         
//         anim.SetInteger("state", --activeTips);
//     }
//
//     private void OnEnable()
//     {
//         displayTipEvent += displayTip;
//         disableTipEvent+= disableTip;
//     }
//     private void OnDisable()
//     {
//         displayTipEvent -= displayTip;
//         disableTipEvent-= disableTip;
//     }
// }
using System;
using TMPro;
using UnityEngine;

public class tipsManager : MonoBehaviour
{
    public static Action<string> displayTipEvent;
    public static Action disableTipEvent;
    [SerializeField] private TMP_Text messageText;
    private int longMessageLength = 20;
    private Animator anim;
    private int activeTips;
    private float shortDelay = 3f; 
    private float longDelay = 5f;
    private float timer = 0f;
    private bool isTipActive = false;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (isTipActive)
        {
            timer += Time.deltaTime;
            float currentDelay = messageText.text.Length >= longMessageLength ? longDelay : shortDelay;
            if (timer >= currentDelay)
            {
                DisableTip();
            }
        }
    }

    void DisplayTip(string message)
    {
        messageText.text = message;
        timer = 0f; // Сбрасываем таймер при новой подсказке
    
        // Всегда обновляем состояние аниматора
        activeTips = 1; // Устанавливаем 1 (показываем подсказку)
        anim.SetInteger("state", activeTips);
    
        isTipActive = true;
    }
    void DisableTip()
    {
        if (activeTips > 0)
        {
            activeTips--;
            anim.SetInteger("state", activeTips);
            
            if (activeTips == 0)
            {
                isTipActive = false;
                timer = 0f;
            }
        }
    }

    private void OnEnable()
    {
        displayTipEvent += DisplayTip;
        disableTipEvent += DisableTip;
    }

    private void OnDisable()
    {
        displayTipEvent -= DisplayTip;
        disableTipEvent -= DisableTip;
    }
}