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
    public void Mostrar()  //Condición para activar el canvasSeBuscan, que aparezca el personaje a buscar y que este desactivado el HUD.
    {
        canvasSeBuscan.SetActive(true);
        PositionOfCharacters();
        canvasHud.SetActive(false);
    }

    public void Cerrar()  //Condición que desactiva el canvasSeBuscan y activa el  HUD.
    {
        canvasSeBuscan.SetActive(false);
        canvasHud.SetActive(true);
        GameController.instance.FullLevel();
    }

    public void PositionOfCharacters()  //Condición para que aparezca el personaje en la posición deseada.
    {
        GameObject charac = GameController.instance.RandomCharactersWanted();  //Llama la instancia del GameController RandomCharacters.
        charac.transform.parent = spawnPosition.transform;               //Le dice al objeto del personaje a buscar donde va a aparecer.
        charac.transform.localPosition = Vector3.zero;                   //Le dice al objeto donde esta el personaje a buscar la posición.
        charac.transform.localScale = Vector3.one * 200f;                //Le dice al objeto del personaje a buscar el tamaño que tendrá.
        charac.transform.LookAt(Camera.main.transform);                  //Le dice al objeto del personaje a buscar a donde estará mirando.
    }
}
