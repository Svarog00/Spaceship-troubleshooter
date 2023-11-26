using Assets._Project.Scripts.Entities;
using Assets._Project.Scripts.Global;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace Assets._Project.Scripts.Ship
{
    public class Trouble : MonoBehaviour, IHealth
    {
        public event EventHandler<OnHealthChangedEventArgs> OnHealthChangedEventHandler;

        public bool IsActive => _isActive;

        public float Health => _maxHealth;

        public bool IsMaxHp => _curHealth == _maxHealth;

        [SerializeField] private PlayerPointsManager _playerPointsManager;
        [SerializeField] private GameObject _damagedAppearence;
        [SerializeField] private Light2D _light2D;

        [SerializeField] private ShipConditionController _shipCondition;
        [SerializeField] private int _damagePerTick;
        [SerializeField] private float _maxTimeDelay;

        [SerializeField] private int _damageForFixing;
        [SerializeField] private float _maxHealth;

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
            _light2D.color = Color.white;

            _playerPointsManager.CountSolvedProblem();

            _accumulatedDamage = 0;
        }

        public void ActivateTrouble()
        {
            _curHealth = 0;
            _isActive = true;

            _damagedAppearence.SetActive(_isActive);
            _light2D.color = Color.red;

            OnHealthChangedEventHandler?.Invoke(this, new OnHealthChangedEventArgs { CurrentHealth = _curHealth });
        }

        private void Update()
        {
            if(_isActive)
            {
                _curTimeDelay -= Time.deltaTime;
                if (_curTimeDelay <= 0f)
                {
                    DamageShip();
                    _curTimeDelay = _maxTimeDelay;
                }
            }
        }

        private void DamageShip()
        {
            _shipCondition.Hurt(_damagePerTick);
            _accumulatedDamage += _damagePerTick;
        }

        public void Heal(float damage)
        {
            if(_isActive)
            {
                _curHealth += damage;
                if(_curHealth == _maxHealth)
                {
                    SolveTrouble();
                }

                OnHealthChangedEventHandler?.Invoke(this, new OnHealthChangedEventArgs { CurrentHealth = _curHealth });
            }
        }

        public void SetHealth(float health)
        {
            _curHealth = health;
            OnHealthChangedEventHandler?.Invoke(this, new OnHealthChangedEventArgs { CurrentHealth = _curHealth });
        }

        public void Hurt(float damage)
        {
            
        }
    }
}