using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

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

    public int level = 1;
    float levelMultiplier;
    float chargeRate;

    public GameObject[] clouds;

    private void Start()
    {
        SpawnCloud();
        SpawnCloud();
        SpawnCloud();
        SpawnCloud();

        clouds = Resources.LoadAll("Clouds", typeof(GameObject)).Cast<GameObject>().ToArray();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime * level;
        if (transform.childCount < lowAmount)
        {
            if (timer > lowTimer)
                SpawnCloud();
        }
        else if (transform.childCount < mediumAmount)
        {
            if (timer > mediumTimer)
                SpawnCloud();
        }
        else if (transform.childCount < highAmount)
        {
            if (timer > highTimer)
                SpawnCloud();
        }

        if(!Input.GetKey(KeyCode.LeftShift))
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
                SpawnCloud(1);
            else if (Input.GetKeyDown(KeyCode.Alpha2))
                SpawnCloud(2);
            else if (Input.GetKeyDown(KeyCode.Alpha3))
                SpawnCloud(3);
            else if (Input.GetKeyDown(KeyCode.Alpha4))
                SpawnCloud(4);
            else if (Input.GetKeyDown(KeyCode.Alpha5))
                SpawnCloud(5);
            else if (Input.GetKeyDown(KeyCode.Alpha6))
                SpawnCloud(6);
            else if (Input.GetKeyDown(KeyCode.Alpha7))
                SpawnCloud(7);
            else if (Input.GetKeyDown(KeyCode.Alpha8))
                SpawnCloud(8);
            else if (Input.GetKeyDown(KeyCode.Alpha9))
                SpawnCloud(9);
            else if (Input.GetKeyDown(KeyCode.Alpha0))
                SpawnCloud(10);
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
                SpawnCloud(11);
            else if (Input.GetKeyDown(KeyCode.Alpha2))
                SpawnCloud(12);
            else if (Input.GetKeyDown(KeyCode.Alpha3))
                SpawnCloud(13);
            else if (Input.GetKeyDown(KeyCode.Alpha4))
                SpawnCloud(14);
        }

    }

    void SpawnCloud()
    {
        timer = 0f;

        GameObject spawn = cloud;
        spawn.transform.position = new Vector3(UnityEngine.Random.Range(-22f, -19f), UnityEngine.Random.Range(-9f, 9f), 0f);
        Instantiate(spawn, transform);
    }

    void SpawnCloud(int number)
    {
        GameObject spawn = clouds[number - 1];

        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pos.z = 0;

        spawn.transform.position = pos;
        Instantiate(spawn, transform);
    }

    public void UpdateMultiplier(int level)
    {
        chargeRate = 1 + (level * levelMultiplier);
    }
}
