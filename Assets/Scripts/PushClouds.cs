using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushClouds : MonoBehaviour
{
    public float range;
    public float maxPower;
    public float windForce;
    float decay;

    Vector3 mousePosition;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;

        decay = maxPower / range;

        foreach (Transform child in transform)
        {
            Debug.DrawLine(mousePosition, child.position);
            float distance = Vector2.Distance(mousePosition, child.position);
            if (distance < range)
            {
                distance = distance / range;

                //B - A, then normalized with force applied
                Vector2 direction = child.position - mousePosition;

                //child.GetComponent<Rigidbody2D>().AddForce(direction.normalized * (maxPower - (decay * distance)));
                child.GetComponent<Rigidbody2D>().AddForce(direction.normalized * ((maxPower / (distance + 0.5f)) - 0.66f));
                Debug.Log(distance + " and " + ((1/(distance + 0.5f)) - 0.66f));
            }
            else
            {
                //drag clouds in the wind or something
                child.GetComponent<Rigidbody2D>().AddForce(Vector2.right * windForce);
            }
        }
    }
}
