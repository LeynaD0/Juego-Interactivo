using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HidePoints : MonoBehaviour
{
    public GameObject[] hidePoints;
    public int cantidadDeHidePoints;
    public static HidePoints instance;
    


    private void Awake()
    {
        if (HidePoints.instance == null)
        {
            HidePoints.instance = this;
            //DontDestroyOnLoad(gameObject);
        }

        else
        {
            Destroy(gameObject);
        }
    }
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

    public void limpiarHidePoints()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).childCount > 0)
            {
                Destroy(transform.GetChild(i).GetChild(0).gameObject);
            }
        }
    }

    public int GetNumberEscondite()
    {
        return transform.childCount;
    }
}
