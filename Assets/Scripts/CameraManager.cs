using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

public class CameraManager : MonoBehaviour
{
    public Dictionary<int, string> vagas = new Dictionary<int, string>();

    void Start()
    {
        StartCoroutine(UpdateVagas());
    }

    public void AdicionarCarro(int vagaId, string placa)
    {
        if (!vagas.ContainsKey(vagaId))
        {
            vagas.Add(vagaId, placa);
        }
        else
        {
            vagas[vagaId] = placa;
        }
    }

    public void RemoverCarro(int vagaId)
    {
        if (vagas.ContainsKey(vagaId))
        {
            string placa = vagas[vagaId];
            vagas.Remove(vagaId);
            StartCoroutine(RemoveCarroFromVaga(vagaId, placa));
        }
    }

    IEnumerator RemoveCarroFromVaga(int vagaId, string placa)
    {
        // Obter o ID do carro usando a placa
        string urlGetCarro = "http://localhost:1337/api/carros?filters[placa][$eq]=" + placa;
        UnityWebRequest getRequest = UnityWebRequest.Get(urlGetCarro);
        yield return getRequest.SendWebRequest();

        if (getRequest.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError("Erro ao obter carro: " + getRequest.error);
        }
        else
        {
            var getResponseJson = JObject.Parse(getRequest.downloadHandler.text);
            int carroId = (int)getResponseJson["data"][0]["id"];

            // Atualizar a vaga para remover o ID do carro
            string urlUpdateVaga = "http://localhost:1337/api/vagas/" + vagaId;
            string jsonData = "{\"data\":{\"carro\":null}}";
            UnityWebRequest putRequest = UnityWebRequest.Put(urlUpdateVaga, jsonData);
            putRequest.SetRequestHeader("Content-Type", "application/json");
            yield return putRequest.SendWebRequest();

            if (putRequest.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError("Erro ao atualizar a vaga " + vagaId + ": " + putRequest.error);
                Debug.LogError("Response: " + putRequest.downloadHandler.text);
            }
            else
            {
                Debug.Log("Vaga atualizada: " + putRequest.downloadHandler.text);
            }
        }
    }

    IEnumerator UpdateVagas()
    {
        while (true)
        {
            foreach (KeyValuePair<int, string> entry in vagas)
            {
                int vagaId = entry.Key;
                string placa = entry.Value;

                // Obter o ID do carro usando a placa
                string urlGetCarro = "http://localhost:1337/api/carros?filters[placa][$eq]=" + placa;
                UnityWebRequest getRequest = UnityWebRequest.Get(urlGetCarro);
                yield return getRequest.SendWebRequest();

                if (getRequest.result != UnityWebRequest.Result.Success)
                {
                    Debug.LogError("Erro ao obter carro: " + getRequest.error);
                }
                else
                {
                    var getResponseJson = JObject.Parse(getRequest.downloadHandler.text);
                    int carroId = (int)getResponseJson["data"][0]["id"];

                    // Atualizar a vaga com o ID do carro
                    string urlUpdateVaga = "http://localhost:1337/api/vagas/" + vagaId;
                    var data = new
                    {
                        data = new
                        {
                            carro = carroId
                        }
                    };
                    string jsonData = JsonConvert.SerializeObject(data);
                    UnityWebRequest putRequest = UnityWebRequest.Put(urlUpdateVaga, jsonData);
                    putRequest.SetRequestHeader("Content-Type", "application/json");
                    yield return putRequest.SendWebRequest();

                    if (putRequest.result != UnityWebRequest.Result.Success)
                    {
                        Debug.LogError("Erro ao atualizar a vaga " + vagaId + ": " + putRequest.error);
                        Debug.LogError("Response: " + putRequest.downloadHandler.text);
                    }
                    else
                    {
                        Debug.Log("Vaga atualizada: " + putRequest.downloadHandler.text);
                    }
                }
            }
            yield return new WaitForSeconds(1f); // Espera 5 segundos antes de atualizar novamente
        }
    }
}