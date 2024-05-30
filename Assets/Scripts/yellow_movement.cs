using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class yellow_movement : MonoBehaviour
{
    private Rigidbody yellowRB;
    int timer;
    int i;
    int j;
    int k;
    // Start is called before the first frame update
    void Start()
    {
        yellowRB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < 460)
        {
            timer = timer + 1;
        }
        else
        {
            if (i < 20)
            {
                yellowRB.AddForce(Vector3.back * 20);
                i = i + 1;
            }
            else if (j < 90)
            {
                transform.Rotate(Vector3.down * 1);
                j = j + 1;
            }
            else if (k < 120 && j == 90)
            {
                yellowRB.AddForce(Vector3.left * 20);
                k = k + 1;
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}
