using Assets._Project.Scripts.Entities;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShipConditionController : MonoBehaviour, IHealth
{
    public event EventHandler<OnHealthChangedEventArgs> OnHealthChangedEventHandler;
    public float Health => _maxHullCapacity;

    public bool IsMaxHp => _currentHullCapacity == _maxHullCapacity;

    private const string EndScreenSceneName = "EndScreen";

    [SerializeField] private float _maxHullCapacity;
    private float _currentHullCapacity;

    private void Awake()
    {
        _currentHullCapacity = _maxHullCapacity;
        OnHealthChangedEventHandler?.Invoke(this, new OnHealthChangedEventArgs { CurrentHealth = _currentHullCapacity });
    }

    public void Heal(float damage)
    {
        _currentHullCapacity += damage;
        OnHealthChangedEventHandler?.Invoke(this, new OnHealthChangedEventArgs { CurrentHealth = _currentHullCapacity });
    }

    public void Hurt(float damage)
    {
        _currentHullCapacity -= damage;
        OnHealthChangedEventHandler?.Invoke(this, new OnHealthChangedEventArgs { CurrentHealth = _currentHullCapacity });

        if(_currentHullCapacity <= 0)
        {
            SceneManager.LoadScene(EndScreenSceneName);
        }
    }
}

