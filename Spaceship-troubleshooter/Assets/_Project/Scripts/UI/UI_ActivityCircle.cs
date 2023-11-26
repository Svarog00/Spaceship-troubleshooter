using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_ActivityCircle : MonoBehaviour
{
    [SerializeField] private GameObject _visual;
    [SerializeField] private Vector3 _rotation;

    private float _duration = 0.5f;

    private void Start()
    {
        //_visual.SetActive(false);

        Sequence sequence = DOTween.Sequence();
        sequence.Append(_visual.transform.DORotate(_visual.transform.rotation.eulerAngles + _rotation, _duration))
            .Append(_visual.transform.DOShakePosition(0.5f).SetLoops(-1));
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
