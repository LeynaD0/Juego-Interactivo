using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WantedScreen : MonoBehaviour
{
    public static WantedScreen instance;
    
    public GameObject spawnPosition;
    
    public GameObject canvasSeBuscan;
    
    public GameObject canvasHud;

    
    public float tiempo = 5f;

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
    public void Mostrar()  //Condici�n para activar el canvasSeBuscan, que aparezca el personaje a buscar y que este desactivado el HUD.
    {
        canvasSeBuscan.SetActive(true);
        PositionOfCharacters();
        if (canvasHud != null) 
        {
            canvasHud.SetActive(false);
        }
        
    }

    public void Cerrar()  //Condici�n que desactiva el canvasSeBuscan y activa el  HUD.
    {
        canvasSeBuscan.SetActive(false);
        if (canvasHud != null)
        {
            canvasHud.SetActive(true);
        }

        
        GameController.instance.FullLevel();
        GameController.instance.isPlaying = true;
    }

    public void PositionOfCharacters()  //Condici�n para que aparezca el personaje en la posici�n deseada.
    {
        if(spawnPosition.transform.childCount > 0)
        {
            Destroy(spawnPosition.transform.GetChild(0).gameObject);
        }
        GameObject charac = GameController.instance.RandomCharactersWanted();  //Llama la instancia del GameController RandomCharacters.
        charac.transform.parent = spawnPosition.transform;               //Le dice al objeto del personaje a buscar donde va a aparecer.
        charac.transform.localPosition = Vector3.zero;                   //Le dice al objeto donde esta el personaje a buscar la posici�n.
        charac.transform.localScale = Vector3.one * 200f;                //Le dice al objeto del personaje a buscar el tama�o que tendr�.
        charac.transform.LookAt(Camera.main.transform);                  //Le dice al objeto del personaje a buscar a donde estar� mirando.
    }

    public void PositionOnPause()
    {
        GameObject charac = GameController.instance.MismoPersonajeEnPausa();  //Llama la instancia del GameController RandomCharacters.
        charac.transform.parent = spawnPosition.transform;               //Le dice al objeto del personaje a buscar donde va a aparecer.
        charac.transform.localPosition = Vector3.zero;                   //Le dice al objeto donde esta el personaje a buscar la posici�n.
        charac.transform.localScale = Vector3.one * 200f;                //Le dice al objeto del personaje a buscar el tama�o que tendr�.
        charac.transform.LookAt(Camera.main.transform);
    }
}
