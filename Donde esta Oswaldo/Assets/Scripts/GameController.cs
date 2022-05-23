using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    public GameObject[] personajesDisponibles;
    public int Personajes;

    private void Awake()
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
    private void Start()
    {
        
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);       
        }
    }

    public GameObject RandomCharacters()
    {
        Personajes = Random.Range(0, personajesDisponibles.Length);
        return Instantiate(personajesDisponibles[Personajes]);
    }

    
}
