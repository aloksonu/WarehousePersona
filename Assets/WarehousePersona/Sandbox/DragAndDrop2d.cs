using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop2d : MonoBehaviour
{
    Vector3 mousePosition;
    Vector3 initialPosition;

    void Start()
    {
        initialPosition = this.transform.position;
    }

    private Vector3 GetMousePosition()
    {
        return Camera.main.WorldToScreenPoint(transform.position);
    }

    private void OnMouseDown()
    {
        mousePosition = Input.mousePosition - GetMousePosition();
    }

    private void OnMouseDrag()
    {
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition - mousePosition);
    }

    private void OnMouseUp()
    {
        transform.position = initialPosition;
    }

}
