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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        pointsLevel.text = GameController.instance.points.ToString();
    }

    public void NextLevel()
    {
        GameController.instance.nivel++;
        SceneManager.LoadScene(Random.Range(1, 3));
        popUpPoints.SetActive(false);
    }

    public void ReloadLevelLivingRoom()
    {
        SceneManager.LoadScene(1);
        popUpPoints.SetActive(false);
    }

    public void ReloadLevelExterior()
    {
        SceneManager.LoadScene(2);
        popUpPoints.SetActive(false);

    }

    public void Back2Menu()
    {
        SceneManager.LoadScene(0);
        popUpPoints.SetActive(false);

    }
}
