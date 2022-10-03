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
        public IHealth Health => _entityHealth;

        public bool IsAvialable => _droneModel.IsAvialable;

        [SerializeField] private DroneType _type;

        [SerializeField] private float _startFixingTime;
        [SerializeField] private int _maxHp;

        private GameObject _trouble;
        private EntityStateMachine _stateMachine;

        private IHealth _entityHealth;
        private DroneModel _droneModel;

        public event EventHandler<OnHealthChangedEventArgs> OnHealthChangedEventHandler;
        public event EventHandler OnGetNewTask;

        public void SetCurrentObjective(GameObject trouble)
        {
            _trouble = trouble;
            OnGetNewTask?.Invoke(this, EventArgs.Empty);
        }

        void Awake()
        {
            _droneModel = new DroneModel(_startFixingTime);
            _stateMachine = new EntityStateMachine();
            _stateMachine.States = new Dictionary<Type, IBehaviourState>
            {
                [typeof(MovingToTroubleState)] = new MovingToTroubleState(gameObject, _stateMachine),
                [typeof(FixingState)] = new FixingState(gameObject, _stateMachine),
                [typeof(IdleState)] = new IdleState(gameObject, _stateMachine)
            };

            _entityHealth = new DroneHealth(_maxHp);
            _entityHealth.OnHealthChangedEventHandler += _entityHealth_OnHealthChangedEventHandler;
        }

        // Start is called before the first frame update
        void Start()
        {
            _stateMachine.ChangeState<IdleState>();
        }

        private void _entityHealth_OnHealthChangedEventHandler(object sender, OnHealthChangedEventArgs e)
        {
            if (e.CurrentHealth <= 0)
            {
                gameObject.SetActive(false);
                //TODO: Go to broken state awaiting for repair
            }
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
            _entityHealth.Heal(damage);
        }

        public void Hurt(int damage)
        {
            _entityHealth.Hurt(damage);

        }
    }
}