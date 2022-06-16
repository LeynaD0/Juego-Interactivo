using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController instance;

    public GameObject menuPantalla;

    public GameObject[] personajes;

    public int iChar;

    public GameObject personajeBuscado;

    public int nivel = 1;

    public int division = 2;

    public bool isPlaying = false;

    public int points = 0;

    public void Awake()
    {
        menuPantalla.SetActive(true);
    }
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

        RandomCharactersWanted();
    }
    

    private void Update()
    {
        Raycasting();
        
    }

    public GameObject RandomCharactersWanted() //Este es Maduro en otro pais
    {
        iChar = Random.Range(0, personajes.Length);

        personajeBuscado = personajes[iChar];
        personajeBuscado = Instantiate(personajes[iChar]);

        personajeBuscado.tag = "Buscado";

        return personajeBuscado;
    }

    public GameObject MismoPersonajeEnPausa()
    {
        personajeBuscado = personajes[iChar];
        personajeBuscado = Instantiate(personajes[iChar]);

        personajeBuscado.tag = "Buscado";

        return personajeBuscado;
    }
    public GameObject RandomCharactersLevel() // Estos son los mamaguevazos que te complican el nivel
    {
        int cualquiera = Random.Range(0, personajes.Length);
        while (cualquiera == iChar)
        {
            cualquiera = Random.Range(0, personajes.Length);
        }

        //GameObject RandomChar = personajes[cualquiera];

        return Instantiate(personajes[cualquiera]);
    }

    

    public void FullLevel()
    {
        //int hide = HidePoints.instance.RandomHidePoints();
        GameObject escondite = HidePoints.instance.RandomHidePoints();
        //personajeBuscado.transform.parent = HidePoints.instance.hidePoints[hide].transform;
        personajeBuscado.transform.parent = escondite.transform;
        personajeBuscado.transform.localPosition = Vector3.zero;
        personajeBuscado.transform.localScale = Vector3.one;
        personajeBuscado.transform.LookAt(Camera.current.transform);

        OtherCharacters();
    }

    public void OtherCharacters()
    {
        for (int i = 0; i < (nivel*5)-1; i++)
        {
            /*GameController.instance.personajes[i] = GameController.instance.RandomCharactersLevel();
            GameController.instance.personajes[i].transform.parent = HidePoints.instance.hidePoints[HidePoints.instance.RandomHidePoints()].transform;
            GameController.instance.personajes[i].transform.localPosition = Vector3.zero;
            GameController.instance.personajes[i].transform.LookAt(Camera.main.transform);*/
            GameObject personajes = RandomCharactersLevel();
            GameObject escondites = HidePoints.instance.RandomHidePoints();
            personajes.transform.parent = escondites.transform;
            personajes.transform.localPosition = Vector3.zero;
            personajes.transform.localScale = Vector3.one;
            personajes.transform.LookAt(Camera.current.transform);
        }
    }

    void Ganar()
    {
        isPlaying = false;
        Debug.Log("Encontrado");
        //nivel++;
        Debug.Log(nivel);
        points = points + 100;
        Debug.Log(points);
        PoPUpPoints.instance.popUpPoints.SetActive(true);
        PoPUpPoints.instance.popUpWin.SetActive(true);
        PoPUpPoints.instance.popUpLose.SetActive(false);
    }

    void Perdiste()
    {
        isPlaying = false;
        Debug.Log("Ese no es");
        PoPUpPoints.instance.popUpPoints.SetActive(true);
        PoPUpPoints.instance.popUpLose.SetActive(true);
        PoPUpPoints.instance.popUpWin.SetActive(false);
    }

    void PowerUp()
    {
        Debug.Log("Has destruido la mitad");
        //Destroy(transform.GetChild(RandomCharactersLevel(personajes)).GetChild(0).gameObject;
    }

    
    public void Raycasting()
    {
        if(isPlaying == true)
        {
            
            if ((Input.touchCount >= 1  && Input.GetTouch(0).phase == TouchPhase.Ended) || (Input.GetMouseButtonUp(0)))
            {
                Vector3 pos = Input.mousePosition;
                if( Application.platform == RuntimePlatform.Android)
                {
                    pos = Input.GetTouch(0).position;
                }

                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hitinfo;
                if (Physics.Raycast(ray, out hitinfo))
                {
                    if(hitinfo.transform.tag == ("Buscado"))
                    {
                        Ganar();
                    }

                    if (hitinfo.transform.tag == ("Personajes"))
                    {
                        Perdiste();
                    }

                    if (hitinfo.transform.tag == ("PowerUp"))
                    {
                        PowerUp();
                    }
                }
            }
        }
    }

}
