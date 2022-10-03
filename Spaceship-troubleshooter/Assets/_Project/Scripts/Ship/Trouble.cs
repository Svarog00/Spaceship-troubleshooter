using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets._Project.Scripts.Ship
{
    public class Trouble : MonoBehaviour
    {
        [SerializeField] private GameObject _damagedAppearence;

        [SerializeField] private int _damagePerTick;
        [SerializeField] private ShipConditionController _shipCondition;

        private int _accumulatedDamage;
        private bool _isActive;

        public void SolveTrouble()
        {
            _shipCondition.Heal(_accumulatedDamage);
            _isActive = false;
            _damagedAppearence.SetActive(_isActive);
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
                DamageShip();
            }
        }

        private void DamageShip()
        {
            _shipCondition.Hurt(_damagePerTick);
            _accumulatedDamage += _damagePerTick;
        }
    }
}