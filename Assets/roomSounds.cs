// using UnityEngine;

// public class roomSounds : MonoBehaviour
// {
//     [SerializeField] private AudioClip roomTheme;
//     private GameObject room;
//     private bool isPlaying = false;

//     void Start()
//     {
//         room = GameObject.Find("room2");
//     }

//     void Update()
//     {
//         if (room != null)
//         {
//             // Если комната активна и музыка не играет
//             if (room.activeInHierarchy && !isPlaying)
//             {
//                 SoundManager.instance.PlaySound(roomTheme);
//                 isPlaying = true;
//             }
//             // Если комната неактивна и музыка играет
//             else if (!room.activeInHierarchy && isPlaying)
//             {
//                 SoundManager.instance.PauseSound();
//                 isPlaying = false;
//             }
//         }
//     }
// }