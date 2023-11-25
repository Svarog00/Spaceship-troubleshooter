using Assets._Project.Scripts.Ship;
using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class TroubleGenerator : MonoBehaviour
{
    [SerializeField] private CameraMovement _camera;
    [SerializeField] private List<Trouble> _troubles;

    [Range(0f, 10f)]
    [SerializeField] private float _timeBetweenTroubles = 10f;

    private float _currentTime;

    private void Start()
    {
        ActivateRandomTrouble();
        _currentTime = _timeBetweenTroubles;
    }

    // Update is called once per frame
    void Update()
    {
        _currentTime -= Time.deltaTime;
        if (_currentTime <= 0f)
        {
            _currentTime = _timeBetweenTroubles;
            ActivateRandomTrouble();
        }
    }

    private IEnumerator CountDelay()
    {
        _currentTime = _timeBetweenTroubles;
        while(_currentTime > 0f)
        {
            _currentTime -= Time.deltaTime;
            yield return null;
        }
    }

    private void ActivateRandomTrouble()
    {
        _camera.Shake(0.5f, 0.4f);

        var inactiveTroubles = _troubles.Where(trouble => trouble.IsActive == false).ToList();
        if(inactiveTroubles.Count > 0)
        {
            int random = Random.Range(0, inactiveTroubles.Count);
            inactiveTroubles[random].ActivateTrouble();
        }

        //StartCoroutine(CountDelay());
    }
}
