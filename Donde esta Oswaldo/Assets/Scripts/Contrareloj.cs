using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Contrareloj : MonoBehaviour
{
    public static Contrareloj instance;
    public TextMeshProUGUI textContraReloj;
    public TextMeshProUGUI textContraReloj1;
    public TextMeshProUGUI textContraReloj2;
    public TextMeshProUGUI textContraReloj3;
    public TextMeshProUGUI textContraReloj4;
    public float contraReloj = 20f;
    void Awake()
    {
        if(Contrareloj.instance == null)
        {
            Contrareloj.instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (WantedScreen.instance.tiempo < 0.0f)
        {
            if(PoPUpPoints.instance.popUpPoints.activeSelf == false)
            {
                contraReloj -= Time.deltaTime;
                textContraReloj.text = contraReloj.ToString("f0");
                textContraReloj1.text = contraReloj.ToString("f0");
                textContraReloj2.text = contraReloj.ToString("f0");
                textContraReloj3.text = contraReloj.ToString("f0");
                textContraReloj4.text = contraReloj.ToString("f0");
            }
            

            if(contraReloj <= 0)
            {
                GameController.instance.isPlaying = false;
                PoPUpPoints.instance.popUpPoints.SetActive(true);
                PoPUpPoints.instance.popUpLose.SetActive(true);
                WantedScreen.instance.canvasHud.SetActive(false);
            }
        }
    }
}
