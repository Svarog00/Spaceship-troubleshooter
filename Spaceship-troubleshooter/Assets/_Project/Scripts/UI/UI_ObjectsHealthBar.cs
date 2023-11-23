using Assets._Project.Scripts.Entities;
using DG.Tweening;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_ObjectsHealthBar : MonoBehaviour
{
    [SerializeField] private GameObject _healthSource;
    [SerializeField] private List<Image> _healthBarImage;

    private float _maxValue;
    private Color _currentColor;

    // Start is called before the first frame update
    void Start()
    {
        _maxValue = _healthSource.GetComponent<IHealth>().Health;
        _healthSource.GetComponent<IHealth>().OnHealthChangedEventHandler += HealthSource_OnHealthChangedEventHandler;
    }

    private void HealthSource_OnHealthChangedEventHandler(object sender, OnHealthChangedEventArgs e)
    {
        if(e.CurrentHealth == 0)
        {
            foreach (var image in _healthBarImage)
            {
                image.DOColor(Color.black, .5f);
                image.enabled = false;
            }
            return;
        }    

        var percentage = Math.Round(e.CurrentHealth / _maxValue, 1);
        for (int i = 0; i < _healthBarImage.Count; i++)
        {
            _healthBarImage[i].enabled = DisplayHealthPart(e.CurrentHealth, i);
        }

        if (percentage < 0.5f && _currentColor != Color.red)
        {
            _currentColor = Color.red;
            foreach (var image in _healthBarImage)
            {
                image.DOColor(_currentColor, .5f);
            }
        }
        else if (percentage >= 0.5f && percentage < 1f && _currentColor != Color.yellow)
        {
            _currentColor = Color.yellow;
            foreach (var image in _healthBarImage)
            {
                image.DOColor(_currentColor, .5f);
            }
        }
        else if (percentage >= 1f && _currentColor != Color.green)
        {
            _currentColor = Color.green;
            foreach (var image in _healthBarImage)
            {
                image.DOColor(_currentColor, .5f);
            }
        }
    }

    private bool DisplayHealthPart(float curHealth, int part)
    {
        return part * 20 < curHealth;
    }
}
