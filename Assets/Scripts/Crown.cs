using UnityEngine;
using UnityEngine.EventSystems;

public class Crown : MonoBehaviour, IDragHandler, IDropHandler
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
        if (GameObject.Find("Pedestal").GetComponent<CrownScale>().isSolved) return;

        if (Camera.main == null) return;
        Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(newPosition.x, newPosition.y, transform.position.z);
    }

    public void OnDrop(PointerEventData eventData)
    {
        var crownScale = GameObject.Find("Pedestal");
        bool dropedInsideOfBox = false;
        if (Camera.main == null) return;
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        for (int i = 0; i < crownScale.GetComponent<CrownScale>().scaleBoxes.Length; i++)
        {
            if (mousePosition.x <= crownScale.GetComponent<CrownScale>().scaleBoxes[i].transform.position.x +
                crownScale.GetComponent<CrownScale>().scaleBoxes[i].GetComponent<BoxCollider2D>().size.x / 2 &&
                mousePosition.x >= crownScale.GetComponent<CrownScale>().scaleBoxes[i].transform.position.x -
                crownScale.GetComponent<CrownScale>().scaleBoxes[i].GetComponent<BoxCollider2D>().size.x / 2 &&
                mousePosition.y <= crownScale.GetComponent<CrownScale>().scaleBoxes[i].transform.position.y +
                crownScale.GetComponent<CrownScale>().scaleBoxes[i].GetComponent<BoxCollider2D>().size.y / 2 &&
                mousePosition.y >= crownScale.GetComponent<CrownScale>().scaleBoxes[i].transform.position.y -
                crownScale.GetComponent<CrownScale>().scaleBoxes[i].GetComponent<BoxCollider2D>().size.y / 2
               )
            {
                transform.position = new Vector3(crownScale.GetComponent<CrownScale>().scaleBoxes[i].transform.position.x,
                    crownScale.GetComponent<CrownScale>().scaleBoxes[i].transform.position.y, transform.position.z);

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