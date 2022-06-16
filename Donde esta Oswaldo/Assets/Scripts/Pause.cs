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
        WantedScreen.instance.Mostrar();
        

        if (WantedScreen.instance.canvasSeBuscan == true)
        {
            HidePoints.instance.limpiarHidePoints();
            WantedScreen.instance.canvasHud.SetActive(false);
        }
    }
}
