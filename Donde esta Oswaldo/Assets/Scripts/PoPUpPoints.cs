using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PoPUpPoints : MonoBehaviour
{
    public static PoPUpPoints instance;

    public TextMeshProUGUI pointsLevel;
    public TextMeshProUGUI totalPoints;

    public GameObject popUpPoints;
    public GameObject popUpLose;
    public GameObject popUpWin;
    // Start is called before the first frame update
    void Awake()
    {
        if (PoPUpPoints.instance == null)
        {
            PoPUpPoints.instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        pointsLevel.text = GameController.instance.points.ToString();
    }

    public void NextLevel()
    {
        HidePoints.instance.limpiarHidePoints();
        GameController.instance.nivel++;
        if(GameController.instance.nivel * 5 > HidePoints.instance.GetNumberEscondite())
        {
            Debug.Log("Felicidades, ganaste");
        }
        else
        {
            popUpPoints.SetActive(false);
            WantedScreen.instance.Mostrar();
        }

        popUpPoints.SetActive(false);
        popUpWin.SetActive(false);
        SceneManager.LoadScene(Random.Range(1, 3));
    }

    public void ReloadLevel()
    {
       
        HidePoints.instance.limpiarHidePoints();
        popUpPoints.SetActive(false);
        SceneManager.LoadScene(Random.Range(1, 3));
    }

    public void Back2Menu()
    {
        HidePoints.instance.limpiarHidePoints();
        popUpPoints.SetActive(false);
        GameController.instance.nivel = 0;
        SceneManager.LoadScene(0);
    }
}
