using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HidePoints : MonoBehaviour
{
    public GameObject[] hidePoints;
    public int cantidadDeHidePoints;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject RandomHidePoints()
    {
        cantidadDeHidePoints = Random.Range(0, hidePoints.Length);

        while (hidePoints[cantidadDeHidePoints].transform.childCount !=0)
        {
            cantidadDeHidePoints = Random.Range(0, hidePoints.Length);
        }
        return hidePoints[cantidadDeHidePoints];
        
    }
}
