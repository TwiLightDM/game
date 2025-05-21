using UnityEngine;

public class Interact : MonoBehaviour
{
    private DisplayImage _currentDisplay;

    void Start()
    {
        GameObject displayObj = GameObject.Find("displayImage");

        if (displayObj != null)
        {
            _currentDisplay = displayObj.GetComponent<DisplayImage>();
        }
        else
        {
            Debug.LogWarning("Не найден объект displayImage!");
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (Camera.main == null) return;

            Vector2 rayPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(rayPosition, Vector2.zero);

            if (hit.collider != null && hit.transform.CompareTag("Interactable"))
            {
                var interactable = hit.transform.GetComponent<IInteractable>();
                if (interactable != null)
                {
                    interactable.Interact(_currentDisplay);
                }
                else
                {
                    Debug.LogWarning("Объект с тегом Interactable не содержит IInteractable.");
                }
            }
        }
    }
}
