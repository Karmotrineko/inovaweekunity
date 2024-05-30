using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blue_movement : MonoBehaviour
{
    Rigidbody blueRB;
    int timer;
    int i;
    int j;
    int k;
    // Start is called before the first frame update
    void Start()
    {
        blueRB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < 1200)
        {
            timer = timer + 1;
        }
        else
        {
            if (i < 20)
            {
                blueRB.AddForce(Vector3.forward * 20);
                i = i + 1;
            }
            else if (j < 90)
            {
                transform.Rotate(Vector3.down * 1);
                j = j + 1;
            }
            else if (k < 120 && j == 90)
            {
                blueRB.AddForce(Vector3.left * 20);
                k = k + 1;
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}
