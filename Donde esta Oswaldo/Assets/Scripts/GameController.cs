using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    public GameObject[] personajes;
    public int iChar;
    public GameObject personajeBuscado;

    private void Start()
    {
        if(GameController.instance == null)
        {
            GameController.instance = this;
            DontDestroyOnLoad(gameObject);
        }

        else
        {
            Destroy(gameObject);
        }
    }
    

    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);       
        }
    }

    public GameObject RandomCharactersLevel()
    {
        int cualquiera = Random.Range(0, personajes.Length);
        while (cualquiera == iChar)
        {
            cualquiera = Random.Range(0, personajes.Length);
        }

        GameObject RandomChar = personajes[cualquiera];

        return Instantiate(RandomChar);
    }

    public GameObject RandomCharactersWanted()
    {
        iChar = Random.Range(0, personajes.Length);
        personajeBuscado = personajes[iChar];
        personajeBuscado = Instantiate(personajes[iChar]);

        return personajeBuscado;
    }

    public void FullLevel()
    {
        int hide = HidePoints.instance.RandomHidePoints();
        personajeBuscado.transform.parent = HidePoints.instance.hidePoints[hide].transform;
        personajeBuscado.transform.localPosition = Vector3.zero;
        personajeBuscado.transform.LookAt(Camera.main.transform);

        HidePoints.instance.OtherCharacters();
    }
    
}
