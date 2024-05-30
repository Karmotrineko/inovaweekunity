using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class green_movement : MonoBehaviour
{
    int timer;
    int i;
    int j;
    int k;
    int l;
    int m;
    int n;
    int o;
    private Rigidbody greenRB;
    // Start is called before the first frame update
    void Start()
    {
        greenRB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < 800)
        {
            timer = timer + 1;
        }
        else
        {
            if (i < 48)
            {
                greenRB.AddForce(Vector3.right * 20);
                i = i + 1;
            }
            else if (j < 90)
            {
                transform.Rotate(Vector3.up * 1);
                j = j + 1;
            }
            else if (k < 30 && j == 90)
            {
                greenRB.AddForce(Vector3.back * 20);
                k = k + 1;
            }
            else if (l < 1300)
            {
                l = l + 1;
            }
            else if (n < 50)
            {
                greenRB.AddForce(Vector3.back * 20);
                n = n + 1;
            }
            else if (m < 90)
            {
                transform.Rotate(Vector3.up * 1);
                m = m + 1;
            }
            else if (o < 120)
            {
                greenRB.AddForce(Vector3.left * 20);
                o = o + 1;
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}
