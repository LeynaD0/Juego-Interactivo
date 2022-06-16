using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public GameObject powerUp;

    private void Awake()
    {
        powerUp.SetActive(false);
    }
    public void ActivePowerUp()
    {
        powerUp.SetActive(true);
    }
}
