using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCameraExterior : MonoBehaviour
{
    public GameObject[] Cameras;  //Una array de las camaras
    public int index;


    private void Update()
    {
        for (int i = 0; i < Cameras.Length; i++)  //Un "for" para que vaya sumando el "i"
        {
            if (i == index)
            {
                Cameras[i].SetActive(true);
            }
            else
            {
                Cameras[i].SetActive(false);
            }
        }
    }

    public void RightButtom()
    {
        index++;

        if (index > 4)
        {
            index = 0;
        }
    }

    public void LeftButtom()
    {
        index--;

        if (index < 0)
        {
            index = 1;
        }
    }
}
