using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combineable : MonoBehaviour
{
    public int level;
    public bool combining;

    public GameObject combineInto;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)  
    {
        Debug.Log("ta");
        if (CompareTag(collision.gameObject.tag))
        {
            Debug.Log("tag");
            if(collision.gameObject.GetComponent<Combineable>().level == level
                && !combining)
            {
                Debug.Log("tag 2!");
                Combine(collision);
            }
        }
            
    }

    // Update is called once per frame
    void Combine(Collision2D collision)
    {
        collision.gameObject.GetComponent<Combineable>().combining = true;
        Vector3 pos = Vector3.Lerp(transform.position, collision.gameObject.transform.position, 0.5f);
        GameObject obj = Instantiate(combineInto, transform.parent);
        obj.transform.position = pos;

        Destroy(collision.gameObject);
        Destroy(gameObject);
    }
}
