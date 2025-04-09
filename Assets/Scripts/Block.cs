using UnityEngine;
using UnityEngine.EventSystems;

public class Block : MonoBehaviour, IDragHandler, IDropHandler
{
    public int correctBoxIndex;
    public int indexOfBox;

    private Vector3 _initialPosition;

    void Start()
    {
        indexOfBox = -1;
        _initialPosition = transform.position;
        gameObject.SetActive(false);
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (GameObject.Find("Scale").GetComponent<Scale>().isSolved) return;

        if (Camera.main == null) return;
        Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(newPosition.x, newPosition.y, transform.position.z);
    }

    public void OnDrop(PointerEventData eventData)
    {
        var scale = GameObject.Find("Scale");
        bool dropedInsideOfBox = false;
        if (Camera.main == null) return;
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        for (int i = 0; i < scale.GetComponent<Scale>().scaleBoxes.Length; i++)
        {
            if (mousePosition.x <= scale.GetComponent<Scale>().scaleBoxes[i].transform.position.x +
                scale.GetComponent<Scale>().scaleBoxes[i].GetComponent<BoxCollider2D>().size.x / 2 &&
                mousePosition.x >= scale.GetComponent<Scale>().scaleBoxes[i].transform.position.x -
                scale.GetComponent<Scale>().scaleBoxes[i].GetComponent<BoxCollider2D>().size.x / 2 &&
                mousePosition.y <= scale.GetComponent<Scale>().scaleBoxes[i].transform.position.y +
                scale.GetComponent<Scale>().scaleBoxes[i].GetComponent<BoxCollider2D>().size.y / 2 &&
                mousePosition.y >= scale.GetComponent<Scale>().scaleBoxes[i].transform.position.y -
                scale.GetComponent<Scale>().scaleBoxes[i].GetComponent<BoxCollider2D>().size.y / 2
               )
            {
                transform.position = new Vector3(scale.GetComponent<Scale>().scaleBoxes[i].transform.position.x,
                    scale.GetComponent<Scale>().scaleBoxes[i].transform.position.y, transform.position.z);

                indexOfBox = i;
                dropedInsideOfBox = true;
            }
        }

        if (!dropedInsideOfBox)
        {
            transform.position = _initialPosition;
            indexOfBox = -1;
        }
    }
}