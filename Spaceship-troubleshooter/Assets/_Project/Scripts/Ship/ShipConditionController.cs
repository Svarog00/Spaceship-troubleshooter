using Assets._Project.Scripts.Entities;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShipConditionController : MonoBehaviour, IHealth
{
    public event EventHandler<OnHealthChangedEventArgs> OnHealthChangedEventHandler;

    private const string EndScreenSceneName = "EndScreen";

    [SerializeField] private int _maxHullCapacity;
    private int _currentHullCapacity;

    private void Awake()
    {
        _currentHullCapacity = _maxHullCapacity;
        OnHealthChangedEventHandler?.Invoke(this, new OnHealthChangedEventArgs { CurrentHealth = _currentHullCapacity });
    }

    public void Heal(int damage)
    {
        _currentHullCapacity += damage;
        OnHealthChangedEventHandler?.Invoke(this, new OnHealthChangedEventArgs { CurrentHealth = _currentHullCapacity });
    }

    public void Hurt(int damage)
    {
        _currentHullCapacity -= damage;
        OnHealthChangedEventHandler?.Invoke(this, new OnHealthChangedEventArgs { CurrentHealth = _currentHullCapacity });

        if(_currentHullCapacity <= 0)
        {
            SceneManager.LoadScene(EndScreenSceneName);
        }
    }
}

