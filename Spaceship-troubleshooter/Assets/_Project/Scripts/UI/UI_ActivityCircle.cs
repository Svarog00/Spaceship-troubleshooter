using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_ActivityCircle : MonoBehaviour
{
    [SerializeField] private GameObject _visual;
    [SerializeField] private Vector3 _rotation;

    private void Start()
    {
        _visual.SetActive(false);
    }

    public void Toggle(bool isActive)
    {
        _visual.SetActive(isActive);
    }

    public void Rotate(float duration)
    {
        _visual.transform.DORotate(_visual.transform.rotation.eulerAngles + _rotation, duration);
    }
}
