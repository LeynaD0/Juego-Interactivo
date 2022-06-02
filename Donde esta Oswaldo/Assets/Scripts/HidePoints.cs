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
            DontDestroyOnLoad(gameObject);
        }

        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        RandomHidePoints();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int RandomHidePoints()
    {
        cantidadDeHidePoints = Random.Range(0, hidePoints.Length);

        while (hidePoints[cantidadDeHidePoints].transform.childCount !=0)
        {
            cantidadDeHidePoints = Random.Range(0, hidePoints.Length);
        }
        return cantidadDeHidePoints;
        
    }

    public void OtherCharacters()
    {
        for(int i = 0; i < hidePoints.Length; i++)
        {
            GameController.instance.personajes[i] = GameController.instance.RandomCharactersLevel();
            GameController.instance.personajes[i].transform.parent = hidePoints[RandomHidePoints()].transform;
            GameController.instance.personajes[i].transform.localPosition = Vector3.zero;
            GameController.instance.personajes[i].transform.LookAt(Camera.main.transform);
        }
    }
}
