using Assets._Project.Scripts.Global;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets._Project.Scripts.Ship
{
    public class Trouble : MonoBehaviour
    {
        [SerializeField] private PlayerPointsManager _playerPointsManager;
        [SerializeField] private GameObject _damagedAppearence;

        [SerializeField] private ShipConditionController _shipCondition;
        [SerializeField] private int _damagePerTick;
        [SerializeField] private float _maxTimeDelay;

        private int _accumulatedDamage;
        private bool _isActive;

        private float _curTimeDelay;

        private void Awake()
        {
            _curTimeDelay = _maxTimeDelay;
        }

        public void SolveTrouble()
        {
            _isActive = false;
            _shipCondition.Heal(_accumulatedDamage);
            _damagedAppearence.SetActive(_isActive);
            _playerPointsManager.CountSolvedProblem();
        }

        public void ActivateTrouble()
        {
            _isActive = true;
            _damagedAppearence.SetActive(_isActive);
        }

        private void Update()
        {
            if(_isActive)
            {
                _curTimeDelay -= Time.deltaTime;
                if (CanDamage())
                {
                    DamageShip();
                    _curTimeDelay = _maxTimeDelay;
                }
            }
        }

        private bool CanDamage() => _curTimeDelay <= 0f;

        private void DamageShip()
        {
            _shipCondition.Hurt(_damagePerTick);
            _accumulatedDamage += _damagePerTick;
        }
    }
}