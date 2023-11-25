using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using DG.Tweening;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform hero;

    public void Update()
    {
        transform.position = new Vector3(hero.position.x, hero.position.y, -1);
    }

    public void Shake(float duration, float strength)
    {
        transform.DOShakePosition(duration, strength);
    }
}
