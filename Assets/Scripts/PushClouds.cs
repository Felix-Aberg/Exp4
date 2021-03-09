﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushClouds : MonoBehaviour
{
    public float range;
    public float maxPower;
    public float windForce;
    float decay;

    public float screenWidth;
    public float screenHeight;
    public float lassoStrength;

    public float telepos;

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
            Drift(child);

            StayWithin(child);

            Loop(child);
        }
    }

    void Drift(Transform child)
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
        }
        else
        {
            //drag clouds in the wind or something
            child.GetComponent<Rigidbody2D>().AddForce(Vector2.right * windForce);
        }
    }

    void StayWithin(Transform child) 
    {
        if (Mathf.Abs(child.position.y) > screenHeight)
        {
            //do it
            Debug.Log("!!!");
            Vector3 force = Vector3.zero;
            force.y = -child.position.y;
            child.GetComponent<Rigidbody2D>().AddForce(force * lassoStrength);
        }
    }

    void Loop(Transform child)
    {
        if (child.position.x > telepos)
        {
            Vector3 pos = child.position;
            pos.x = -pos.x;
            child.position = pos;
        }
    }

}
