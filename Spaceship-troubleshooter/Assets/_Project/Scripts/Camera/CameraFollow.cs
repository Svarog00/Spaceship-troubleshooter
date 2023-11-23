using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private GameObject hero;

    private void Awake()
    {
        GetComponentInChildren<CinemachineVirtualCamera>().Follow = hero.transform;
    }

    public void Follow(GameObject hero)
    {
        GetComponentInChildren<CinemachineVirtualCamera>().Follow = hero.transform;
    }
}
