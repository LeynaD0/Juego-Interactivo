using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCamera : MonoBehaviour
{
    public GameObject livingRoomCamera;
    public GameObject corridorCamera;
    

    public void LivingRoom()
    {
        livingRoomCamera.SetActive(true);
        corridorCamera.SetActive(false);
    }

    public void Corridor()
    {
        livingRoomCamera.SetActive(false);
        corridorCamera.SetActive(true);
    }
}
