using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WantedScreen : MonoBehaviour
{
    public static WantedScreen instance;
    [SerializeField]
    GameObject spawnPosition;
    [SerializeField]
    GameObject seBuscan;
    
    public GameObject buscadoPrefab;

    float tiempo = 5f;
    public TextMeshProUGUI textoTiempo;

    private void Awake()
    {
        if(WantedScreen.instance == null)
        {
            WantedScreen.instance = this;
        }

        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        
    }
    private void Update()
    {
        
        if(tiempo < 5 && tiempo > 1)
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

    public void PositionOfCharacters()
    {
        GameObject charac = GameController.instance.RandomCharacters();
        charac.transform.parent = spawnPosition.transform;
        charac.transform.localPosition = Vector3.zero;
        charac.transform.localScale = Vector3.one * 200f;
        charac.transform.LookAt(Camera.main.transform);
    }
}
