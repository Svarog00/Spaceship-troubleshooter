using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public void ShakeCamera(float duration, float strength)
    {
        transform.DOShakePosition(duration, strength);
    }
}
