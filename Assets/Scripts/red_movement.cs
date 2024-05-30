using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class red_movement : MonoBehaviour
{
    int timer;
    int i;
    int j;
    int k;
    int l;
    private Rigidbody redRB;
    // Start is called before the first frame update
    void Start()
    {
        redRB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (i < 27)
        {
            redRB.AddForce(Vector3.back * 20);
            i = i + 1;
        }
        else if ( timer < 1800)
        {
            timer = timer + 1;
        }
        else if (j < 27)
        {
            redRB.AddForce(Vector3.forward * 20);
            j = j + 1;
        }
        else if (k < 90)
        {
            transform.Rotate(Vector3.up * 1);
            k = k + 1;
        }
        else if (l < 120 && k == 90)
        {
            redRB.AddForce(Vector3.left * 20);
            l = l + 1;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
