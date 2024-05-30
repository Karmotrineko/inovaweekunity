using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarManager : MonoBehaviour
{
    public float intervalo;
    public GameObject carroVermelho;
    public GameObject carroAmarelo;
    public GameObject carroVerde;
    public GameObject carroAzul;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("check", 0f, intervalo);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void check()
    {
        GameObject[] carros = GameObject.FindGameObjectsWithTag("Carro");

        if (carros.Length == 0)
        {
            Instantiate(carroVermelho);
            Instantiate(carroAzul);
            Instantiate(carroVerde);
            Instantiate(carroAmarelo);
        }
    }
}
