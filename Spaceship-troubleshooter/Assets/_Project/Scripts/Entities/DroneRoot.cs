using Assets._Project.Scripts.Entities.BehaviourStates;
using Assets._Project.Scripts.Ship;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets._Project.Scripts.Entities
{
    public enum DroneType { Small, Human }

    public class DroneRoot : MonoBehaviour, IHealth
    {
        public GameObject TroubleObject => _trouble;
        public DroneModel DroneModel => _droneModel;

        public bool IsAvialable => _droneModel.IsAvialable;

        [SerializeField] private DroneType _type;

        [SerializeField] private float _startFixingTime;

        [SerializeField] private int _maxHp;
        private int _currentHealth;

        private DroneModel _droneModel;
        private GameObject _trouble;
        private EntityStateMachine _stateMachine;

        public event EventHandler<OnHealthChangedEventArgs> OnHealthChangedEventHandler;
        public event EventHandler OnGetNewTask;

        public void SetCurrentObjective(GameObject trouble)
        {
            _trouble = trouble;
            OnGetNewTask?.Invoke(this, EventArgs.Empty);
        }

        void Awake()
        {
            _currentHealth = _maxHp;

            _droneModel = new DroneModel(_startFixingTime);
            _stateMachine = new EntityStateMachine();
            _stateMachine.States = new Dictionary<Type, IBehaviourState>
            {
                [typeof(MovingToTroubleState)] = new MovingToTroubleState(gameObject, _stateMachine),
                [typeof(FixingState)] = new FixingState(gameObject, _stateMachine),
                [typeof(IdleState)] = new IdleState(gameObject, _stateMachine)
            };

            OnHealthChangedEventHandler?.Invoke(this, new OnHealthChangedEventArgs { CurrentHealth = _currentHealth });
        }

        // Start is called before the first frame update
        void Start()
        {
            _stateMachine.Enter<IdleState>();
        }

        // Update is called once per frame
        void Update()
        {
            _stateMachine.Work();
        }

        public void Damage()
        {
            
        }

        public void Heal(int damage)
        {
            _currentHealth += damage;
            OnHealthChangedEventHandler?.Invoke(this, new OnHealthChangedEventArgs { CurrentHealth = _currentHealth });
        }

        public void Hurt(int damage)
        {
            _currentHealth -= damage;
            OnHealthChangedEventHandler?.Invoke(this, new OnHealthChangedEventArgs { CurrentHealth = _currentHealth });

            if (_currentHealth <= 0)
            {
                gameObject.SetActive(false);
                //TODO: Go to broken state awaiting for repair
            }
        }
    }
}