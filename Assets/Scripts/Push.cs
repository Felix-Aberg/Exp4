using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Push : MonoBehaviour
{
    public float strength;

    void OnTriggerStay2D(UnityEngine.Collider2D other)
    {
        Debug.Log("AAA");
        Vector3 force = Vector3.zero;
        force.y = -other.transform.position.y;
        other.transform.GetComponent<Rigidbody2D>().AddForce(force * strength);
    }
}
