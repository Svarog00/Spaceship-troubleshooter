using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraFollow : MonoBehaviour, ICameraFollow
{
    public void Follow(GameObject hero)
    {
        GetComponentInChildren<CinemachineVirtualCamera>().Follow = hero.transform;
    }
}
