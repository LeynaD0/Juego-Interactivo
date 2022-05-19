using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WantedScreen : MonoBehaviour
{
    public static WantedScreen instance;
    [SerializeField]
    public GameObject spawnPosition;
    public GameObject seBuscan;

    public float tiempo = 5f;
    public TextMeshProUGUI textoTiempo;
    private void Update()
    {
        
        if(tiempo < 5 && tiempo >= 0)
        {
            Mostrar();
            
        }

        else
        {
            Cerrar();
            
        }

        tiempo -= Time.deltaTime;
        textoTiempo.text = tiempo.ToString("f0");
    }
    public void Mostrar()
    {
        seBuscan.SetActive(true);
    }

    public void Cerrar()
    {
        seBuscan.SetActive(false);
    }
}
