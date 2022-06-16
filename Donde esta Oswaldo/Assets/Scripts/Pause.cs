using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public static Pause instance;
    public bool pauseActive = false;
    public void PauseScript()
    {
        pauseActive = true;
        WantedScreen.instance.tiempo = 5f;
        //WantedScreen.instance.Mostrar();

        MismoPersonaje();

        WantedScreen.instance.canvasSeBuscan.SetActive(true);

        if (WantedScreen.instance.canvasSeBuscan == true)
        {
            HidePoints.instance.limpiarHidePoints();
            WantedScreen.instance.canvasHud.SetActive(false);
        }
    }

    public void MismoPersonaje()
    {
        /*GameController.instance.personajeBuscado = GameController.instance.personajes[GameController.instance.iChar];
        GameController.instance.personajeBuscado = Instantiate(GameController.instance.personajes[GameController.instance.iChar]);

        return GameController.instance.personajeBuscado;*/

        WantedScreen.instance.PositionOnPause();
    }
}
