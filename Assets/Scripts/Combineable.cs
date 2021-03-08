using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combineable : MonoBehaviour
{
    public int level;
    public bool combining;

    public GameObject combineInto;
    public GameObject particleFX;

    // Start is called before the first frame update

    private void OnCollisionEnter2D(Collision2D collision)  
    {
        if (CompareTag(collision.gameObject.tag))
        {
            if(collision.gameObject.GetComponent<Combineable>().level == level
                && !combining)
            {
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
        Instantiate(particleFX, pos, Quaternion.identity);
        obj.transform.position = pos;

        Destroy(collision.gameObject);
        Destroy(gameObject);
    }
}
