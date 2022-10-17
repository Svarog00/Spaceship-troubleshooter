using Assets._Project.Scripts.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets._Project.Scripts.Player.Weapon
{
    public class WieldingTool : MonoBehaviour, IWeapon
    {
        private readonly int FixingAnimationHash = Animator.StringToHash("Fixing");
        private readonly int IdleAnimationHash = Animator.StringToHash("Idle");

        [SerializeField] private int _damage;
        [SerializeField] private float _range;
        [SerializeField] private float _cooldownTime;
        [SerializeField] private LineRenderer _lineRenderer;
        [SerializeField] private Animator _animator;

        private float _curCooldownTime;

        private Vector3 _direction;

        private void Start()
        {
            _lineRenderer.enabled = false;
        }

        private void Update()
        {
            UpdateRayVisual();
            Cooldown();
        }

        public void Shoot()
        {
            _lineRenderer.enabled = true;
            if (CanShoot())
            {
                _direction = GetDirectionToMouse();
                RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, _direction, _range);
                foreach (var hit in hits)
                {
                    IHealth targetHealth;
                    if (hit.collider.TryGetComponent(out targetHealth))
                    {
                        targetHealth.Heal(_damage);
                        break;
                    }
                }
                _curCooldownTime = _cooldownTime;
            }
        }

        private void UpdateRayVisual()
        {
            Vector3 endOfLine = transform.position + GetDirectionToMouse() * _range;
            endOfLine.z = 0;
            _lineRenderer.SetPosition(0, transform.position);
            _lineRenderer.SetPosition(1, endOfLine);


        }

        private void Cooldown()
        {
            if(_curCooldownTime > 0)
            {
                _curCooldownTime -= Time.deltaTime;
            }
        }

        private bool CanShoot()
        {
            return _curCooldownTime <= 0;
        }

        public void StopShoot()
        {
            _lineRenderer.enabled = false;
        }

        private Vector3 GetMousePosition()
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0;
            return mousePosition;
        }

        private Vector3 GetDirectionToMouse()
        {
            Vector3 direction = (GetMousePosition() - transform.position).normalized;
            return direction;
        }
    }
}