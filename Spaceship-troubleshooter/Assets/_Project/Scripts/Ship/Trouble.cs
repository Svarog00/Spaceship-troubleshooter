using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets._Project.Scripts.Ship
{
    public class Trouble : MonoBehaviour
    {
        [SerializeField] private ShipConditionController _shipCondition;
        [SerializeField] private int _damagePerTick;

        private int _accumulatedDamage;
        private bool _isActive;

        public void SolveTrouble()
        {
            _shipCondition.Heal(_accumulatedDamage);
            _isActive = false;
        }

        public void ActivateTrouble()
        {
            _isActive = true;
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