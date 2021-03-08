using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject cloud;

    public int lowAmount;
    public int mediumAmount;
    public int highAmount;

    public float lowTimer;
    public float mediumTimer;
    public float highTimer;

    float timer;


    private void Start()
    {
        SpawnCloud();
        SpawnCloud();
        SpawnCloud();
        SpawnCloud();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        Debug.Log(transform.childCount);
        if (transform.childCount < lowAmount)
        {
            Debug.Log(timer);
            if (timer > lowTimer)
                SpawnCloud();
        }
        else if (transform.childCount < mediumAmount)
        {
            Debug.Log(timer);
            if (timer > mediumTimer)
                SpawnCloud();
        }
        else if (transform.childCount < highAmount)
        {
            if (timer > highTimer)
                SpawnCloud();
        }

    }

    void SpawnCloud()
    {
        Debug.Log("SpawnCloud");

        timer = 0f;

        GameObject spawn = cloud;
        spawn.transform.position = new Vector3(UnityEngine.Random.Range(-22f, -19f), UnityEngine.Random.Range(-9f, 9f), 0f);

        Instantiate(spawn, transform);
    }
}
