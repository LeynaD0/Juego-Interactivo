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
    GameObject canvasSeBuscan;
    [SerializeField]
    GameObject canvasHud;
    
    

    float tiempo = 5f;
    public TextMeshProUGUI textoTiempo;

    private void Start()
    {
        if(WantedScreen.instance == null)
        {
            WantedScreen.instance = this;
            Mostrar();
        }

        else
        {
            Destroy(gameObject);
        }
    }
    private void Update()
    {
        
        if(tiempo < 0.0f )
        {
            Cerrar();

        }

        
        tiempo -= Time.deltaTime;
        textoTiempo.text = tiempo.ToString("f0");
    }
    public void Mostrar()
    {
        canvasSeBuscan.SetActive(true);
        PositionOfCharacters();
        canvasHud.SetActive(false);
    }

    public void Cerrar()
    {
        canvasSeBuscan.SetActive(false);
        canvasHud.SetActive(true);
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
