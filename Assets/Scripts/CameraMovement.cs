using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float rotationSpeed;
    private bool rodou = true;
    public float range1;
    public float range2;

    public string placa;
    public string cor;
    public string modelo;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (rodou)
        {
            transform.Rotate(Vector3.up * rotationSpeed);
            if (transform.rotation.eulerAngles.y < range1)
            {
                rodou = false;
            }
        }
        else
        {
            transform.Rotate(Vector3.down * rotationSpeed);
            if (transform.rotation.eulerAngles.y > range2)
            {
                rodou = true;
            }
        }
    }
}
