using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public Dictionary<int, string>vagas = new Dictionary<int, string>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach(KeyValuePair<int, string> placa in vagas)
            Debug.Log(placa);
    }
}
