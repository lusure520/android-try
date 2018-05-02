using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    private bool isMouseDown = false;
    private Vector3 lastMousePosition = Vector3.zero;

    void Update()
    {
        //check if mouse is pressed
        if (Input.GetMouseButtonDown(0))
        {
            isMouseDown = true;
        }
        //check if mouse is up
        if (Input.GetMouseButtonUp(0))
        {
            isMouseDown = false;
            lastMousePosition = Vector3.zero;//to clear the moved distance when mouse up
        }
        if (isMouseDown)
        {
            if (lastMousePosition != Vector3.zero)
            {
                Vector3 offset = Camera.main.ScreenToWorldPoint(Input.mousePosition) - lastMousePosition;//get distance of mouse moving
                Vector3 newposition = new Vector3(offset.x, 0.0f, 0.0f);
                this.transform.position += newposition;// update new position for items
            }
            lastMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        }
    }
}
