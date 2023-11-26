using Assets._Project.Scripts.Entities;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_ObjectsHealthBar : MonoBehaviour
{
    [SerializeField] private GameObject _healthSource;
    [SerializeField] private Transform _healthBar;

    private List<Image> _healthBarImages;

    private float _maxValue;
    private Color _currentColor;

    private TweenerCore<Color, Color, ColorOptions> _curTweener;

    void Start()
    {
        _maxValue = _healthSource.GetComponent<IHealth>().Health;
        _healthSource.GetComponent<IHealth>().OnHealthChangedEventHandler += HealthSource_OnHealthChangedEventHandler;

        _healthBarImages = new List<Image>();
        foreach (Transform image in _healthBar)
        {
            _healthBarImages.Add(image.GetComponent<Image>());
        }

        _curTweener = null;
    }

    private void HealthSource_OnHealthChangedEventHandler(object sender, OnHealthChangedEventArgs e)
    {
        if(e.CurrentHealth == 0)
        {
            foreach (var image in _healthBarImages)
            {
                image.color = Color.black;
                image.enabled = false;
            }
            return;
        }    

        var percentage = Math.Round(e.CurrentHealth / _maxValue, 1);
        for (int i = 0; i < _healthBarImages.Count; i++)
        {
            _healthBarImages[i].enabled = DisplayHealthPart(e.CurrentHealth, i);
        }

        if (percentage < 0.5f)
        {
            _currentColor = Color.red;
        }
        else if (percentage >= 0.5f && percentage < 1f)
        {
            _currentColor = Color.yellow;
        }
        else if (percentage >= 1f)
        {
            _currentColor = Color.green;
        }

        if(_curTweener == null || _curTweener?.IsPlaying() == false)
        {
            foreach (var image in _healthBarImages)
            {
                _curTweener = image.DOColor(_currentColor, .5f);
            }
        }
    }

    private bool DisplayHealthPart(float curHealth, int part)
    {
        return part * 20 < curHealth;
    }
}
