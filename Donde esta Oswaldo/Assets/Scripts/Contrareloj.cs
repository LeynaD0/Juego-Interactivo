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
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (WantedScreen.instance.tiempo < 0.0f)
        {
            contraReloj -= Time.deltaTime;
            textContraReloj.text = contraReloj.ToString("f0");
            textContraReloj1.text = contraReloj.ToString("f0");
            textContraReloj2.text = contraReloj.ToString("f0");
            textContraReloj3.text = contraReloj.ToString("f0");
            textContraReloj4.text = contraReloj.ToString("f0");

            if(contraReloj < 0.0f)
            {
                PoPUpPoints.instance.popUpLose.SetActive(true);
                WantedScreen.instance.canvasHud.SetActive(false);
            }
        }

        
    }
}
