using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vagaTrigger : MonoBehaviour
{
    private CameraManager cameraManager;
    public int vagaId;

    void Start()
    {
        cameraManager = GameObject.Find("CameraManager").GetComponent<CameraManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Carro"))
        {
            string placa = other.gameObject.GetComponent<carro_info>().placa;
            cameraManager.AdicionarCarro(vagaId, placa);
            Debug.Log($"Carro {placa} entrou na vaga {vagaId}");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Carro"))
        {
            cameraManager.RemoverCarro(vagaId);
            Debug.Log($"Carro saiu da vaga {vagaId}");
        }
    }
}
