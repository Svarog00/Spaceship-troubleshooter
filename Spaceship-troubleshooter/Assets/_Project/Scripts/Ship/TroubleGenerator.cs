using Assets._Project.Scripts.Ship;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class TroubleGenerator : MonoBehaviour
{
    public event EventHandler OnNewTroubleAccurringEventHandler;

    [SerializeField] private List<Trouble> _troubles;
    [SerializeField] private float _timeBetweenTroubles = 10f;

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
        var inactiveTroubles = _troubles.Where(trouble => trouble.IsActive == false).ToList();
        if(inactiveTroubles.Count > 0)
        {
            int random = Random.Range(0, inactiveTroubles.Count);
            inactiveTroubles[random].ActivateTrouble();
        }

        _currentTime = _timeBetweenTroubles;

        OnNewTroubleAccurringEventHandler?.Invoke(this, EventArgs.Empty);
    }
}
