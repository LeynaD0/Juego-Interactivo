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
    public int nivel = 1;
    public bool isPlaying = false;
    public int points = 0;

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
        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);       
        }

        Raycasting();
        
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

        personajeBuscado.tag = "Buscado";

        return personajeBuscado;
    }

    public void FullLevel()
    {
        int hide = HidePoints.instance.RandomHidePoints();
        personajeBuscado.transform.parent = HidePoints.instance.hidePoints[hide].transform;
        personajeBuscado.transform.localPosition = Vector3.zero;
        personajeBuscado.transform.localScale = Vector3.one;
        personajeBuscado.transform.LookAt(Camera.current.transform);

        OtherCharacters();
    }

    public void OtherCharacters()
    {
        for (int i = 0; i < (nivel*5)-1; i++)
        {
            GameController.instance.personajes[i] = GameController.instance.RandomCharactersLevel();
            GameController.instance.personajes[i].transform.parent = HidePoints.instance.hidePoints[HidePoints.instance.RandomHidePoints()].transform;
            GameController.instance.personajes[i].transform.localPosition = Vector3.zero;
            GameController.instance.personajes[i].transform.LookAt(Camera.current.transform);
        }
    }

    public void Raycasting()
    {
        if(isPlaying == true)
        {
            Contrareloj.instance.contraReloj -= Time.deltaTime;
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
                        Debug.Log("Encontrado");
                        //nivel++;
                        Debug.Log(nivel);
                    points = points + 100;
                    Debug.Log(points);
                    PoPUpPoints.instance.popUpPoints.SetActive(true);
                        PoPUpPoints.instance.popUpWin.SetActive(true);
                        PoPUpPoints.instance.popUpLose.SetActive(false);
                        isPlaying = false;                       
                    }

                    if (hitinfo.transform.tag == ("Personajes"))
                    {
                        Debug.Log("Perdiste");
                    PoPUpPoints.instance.popUpLose.SetActive(true);
                    Contrareloj.instance.contraReloj = Contrareloj.instance.contraReloj + 10f;
                    }
                }
            }
        }
    }

}
