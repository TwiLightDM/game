﻿using UnityEngine;

public class ZoomInObject : MonoBehaviour, IInteractable
{
    public float ZoomRatio = .5f;
    [SerializeField] private AudioClip footstepSound;

    public void Interact(DisplayImage currentDisplay)
    {
        SoundManager.instance.PlaySound(footstepSound);
        Camera.main.orthographicSize *= ZoomRatio;
        Camera.main.transform.position = new Vector3(this.transform.position.x, this.transform.position.y,
            Camera.main.transform.position.z);

        gameObject.layer = 2;
        currentDisplay.CurrentState = DisplayImage.State.Zoom;
        
        ConstraintCamera();
    }

    void ConstraintCamera()
    {
        float height = Camera.main.orthographicSize;
        float width = height * Camera.main.aspect;
        GameObject cameraBounds = GameObject.Find("cameraBounds");

        if (Camera.main.transform.position.x + width > cameraBounds.transform.position.x +
            cameraBounds.GetComponent<BoxCollider2D>().size.x / 2)
        {
            Camera.main.transform.position += new Vector3(cameraBounds.transform.position.x +
                cameraBounds.GetComponent<BoxCollider2D>().size.x / 2 - (Camera.main.transform.position.x + width + 0.5f), 0, 0);
        }
        
        if (Camera.main.transform.position.x - width < cameraBounds.transform.position.x -
            cameraBounds.GetComponent<BoxCollider2D>().size.x / 2)
        {
            Camera.main.transform.position += new Vector3(cameraBounds.transform.position.x -
                cameraBounds.GetComponent<BoxCollider2D>().size.x / 2 - (Camera.main.transform.position.x - width - 0.5f), 0, 0);
        }
        
        if (Camera.main.transform.position.y + height > cameraBounds.transform.position.y +
            cameraBounds.GetComponent<BoxCollider2D>().size.y / 2)
        {
            Camera.main.transform.position += new Vector3(0, cameraBounds.transform.position.y +
                cameraBounds.GetComponent<BoxCollider2D>().size.y / 2 - (Camera.main.transform.position.y + height), 0);
        }
        
        if (Camera.main.transform.position.y - height < cameraBounds.transform.position.y -
            cameraBounds.GetComponent<BoxCollider2D>().size.y / 2)
        {
            Camera.main.transform.position += new Vector3(0, cameraBounds.transform.position.y -
                cameraBounds.GetComponent<BoxCollider2D>().size.y / 2 - (Camera.main.transform.position.y - height), 0);
        }
    }
}   