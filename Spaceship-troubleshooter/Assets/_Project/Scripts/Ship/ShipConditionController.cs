using Assets._Project.Scripts.Entities;
using System;
using UnityEngine;

public class ShipConditionController : MonoBehaviour, IHealth
{
    public event EventHandler<OnHealthChangedEventArgs> OnHealthChangedEventHandler;

    [SerializeField] private int _maxHullCapacity;
    private int _currentHullCapacity;

    private void Awake()
    {
        _currentHullCapacity = _maxHullCapacity;
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
    }
}

