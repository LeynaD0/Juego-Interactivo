using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public static CharacterController instance;
    [SerializeField]
    GameObject[] personajesDisponibles;

    private void Awake()
    {
        if(CharacterController.instance == null)
        {
            CharacterController.instance = this;
        }
        else
        {
            Destroy(this);
        }
    }
    public GameObject PersonajeAleatorio()
    {
        return personajesDisponibles[Random.Range(0, personajesDisponibles.Length)];
    }

    public GameObject PersonajeAleatorio(GameObject prefabAparecido)
    {
        GameObject personaje = personajesDisponibles[Random.Range(0, personajesDisponibles.Length)];

        while (personaje == prefabAparecido)
        {
            personaje = personajesDisponibles[Random.Range(0, personajesDisponibles.Length)];
        }

        return personaje;
    }
}
