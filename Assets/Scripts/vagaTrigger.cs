using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vagaTrigger : MonoBehaviour
{
    public carro_info info;
    public CameraMovement cameramovement;
    public bool livre = true;
    private GameObject cameras;
    public int vagaId;
    // Start is called before the first frame update
    void Start()
    {
        cameras = GameObject.Find("CameraManager");
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Carro"))
        {
            cameras.GetComponent<CameraManager>().vagas.Add(vagaId, other.gameObject.GetComponent<carro_info>().placa);
        }
    }
}