using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragDrop : MonoBehaviour
{
    private bool isDragging = false;
    private bool isOverDropZone = false;
    private GameObject dropZone;
    private Vector2 startPosition;


    // Update is called once per frame to detect user input
    void Update()
    {
        if (isDragging)
        {
            //every frame I want to check if isDragging is true.
            //and if isDragging is true, I want the transform position to follow the mouse. I want the object to move to my mouse every frame
            transform.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        }
    }

    //when there is a 2D collission between this object and another one, there will be a collision 2D, and call it collision
    private void OnCollisionEnter2D(Collision2D collision)
    {
        isOverDropZone = true;
        dropZone = collision.gameObject;
    }

    //if wanting to change course and not drop a card on the dropzone, instead of being forced (which code above would do):
    private void OnCollisionExit2D(Collision2D collision)
    {
        isOverDropZone = false;
        dropZone = null;
    }

    public void StartDrag()
    {
        //when we call this method we want the start position to be equal to the transform position
        //and we want to change the boolean, is dragging, to true.
        startPosition = transform.position;
        //wherever the card was intially, we want to store that so we can send card back to start position
        isDragging = true;
    }

    //method to stop dragging.
    public void EndDrag()
    {
        isDragging = false;
        if (isOverDropZone)
        {
            // if dragging over a DropZone, change it so that its a child of whatever the drop zone is
            transform.SetParent(dropZone.transform, false);
        }
        else
        {
            //else, not in a drop zone send card back to the start position established in the StartDrag function
            transform.position = startPosition;
        }
    }
}
