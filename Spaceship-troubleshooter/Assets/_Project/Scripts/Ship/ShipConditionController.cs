using Assets._Project.Scripts.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipConditionController : MonoBehaviour, IHealth
{
    public event EventHandler<OnHealthChangedEventArgs> OnHealthChangedEventHandler;

    [SerializeField] private int _maxHullCapacity;
    private int _currentHullCapacity;

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

