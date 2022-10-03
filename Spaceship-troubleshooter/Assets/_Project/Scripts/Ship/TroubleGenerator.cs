using Assets._Project.Scripts.Ship;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class TroubleGenerator : MonoBehaviour
{
    public event EventHandler OnNewTroubleAccurringEventHandler;

    [SerializeField] private List<Trouble> _troubles;
    [SerializeField] private float _timeBetweenAccurringTroubles = 10f;

    private float _currentTime;

    private void Start()
    {
        ActivateRandomTrouble();
    }

    // Update is called once per frame
    void Update()
    {
        CountTime();
        if (_currentTime <= 0f)
        {
            ActivateRandomTrouble();
        }
    }

    private void CountTime()
    {
        _currentTime -= Time.deltaTime;
    }

    private void ActivateRandomTrouble()
    {
        int random = Random.Range(0, _troubles.Count);
        _troubles[random].ActivateTrouble();

        _currentTime = _timeBetweenAccurringTroubles;

        OnNewTroubleAccurringEventHandler?.Invoke(this, EventArgs.Empty);
    }
}
