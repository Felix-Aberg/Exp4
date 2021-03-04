using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draggable : MonoBehaviour
{
    bool holding;
    Vector3 mousePosition;

    private void OnMouseDown()
    {
        Debug.Log("rsst");
        holding = true;
    }

    private void OnMouseUp()
    {
        if (holding)
        {
            //collider.size = colliderSize;
            holding = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;

        if (holding)
            Hold();
    }

    void Hold()
    {
        Vector3 deltaMouse = mousePosition; // + offset;
        Debug.Log("rs");
        //Sensitivity
        transform.position = deltaMouse;
    }
}
