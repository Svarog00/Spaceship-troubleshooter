using Assets._Project.Scripts.Entities;
using Assets._Project.Scripts.Global;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets._Project.Scripts.Ship
{
    public class Trouble : MonoBehaviour, IHealth
    {
        public event EventHandler<OnHealthChangedEventArgs> OnHealthChangedEventHandler;

        public bool IsActive => _isActive;

        [SerializeField] private PlayerPointsManager _playerPointsManager;
        [SerializeField] private GameObject _damagedAppearence;

        [SerializeField] private ShipConditionController _shipCondition;
        [SerializeField] private int _damagePerTick;
        [SerializeField] private float _maxTimeDelay;

        [SerializeField] private int _damageForFixing;
        [SerializeField] private int _maxHealth;

        private int _accumulatedDamage;
        private bool _isActive;

        private float _curTimeDelay;

        private float _curHealth;

        private void Awake()
        {
            _curTimeDelay = _maxTimeDelay;
            _curHealth = 0;

            _isActive = false;
            _damagedAppearence.SetActive(_isActive);
        }

        public void SolveTrouble(DroneRoot fixingDrone)
        {
            fixingDrone.Hurt(_damageForFixing);
            SolveTrouble();
        }

        private void SolveTrouble()
        {
            _isActive = false;
            _shipCondition.Heal(_accumulatedDamage);
            _damagedAppearence.SetActive(_isActive);
            _playerPointsManager.CountSolvedProblem();
        }

        public void ActivateTrouble()
        {
            _curHealth = 0;
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

        public void Heal(int damage)
        {
            if(_isActive)
            {
                _curHealth += damage;
                if(_curHealth == _maxHealth)
                {
                    SolveTrouble();
                }
            }
        }

        public void Hurt(int damage)
        {
            
        }
    }
}