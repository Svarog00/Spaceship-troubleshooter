using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets._Project.Scripts.Entities.BehaviourStates
{
    public class BrokenState : IBehaviourState
    {
        private GameObject _agentContext;
        private EntityStateMachine _stateMachine;
        private Animator _animator;

        private readonly int IdleAnimationHash = Animator.StringToHash("Idle");

        public BrokenState(GameObject agentContext, EntityStateMachine stateMachine)
        {
            _agentContext = agentContext;
            _stateMachine = stateMachine;

            _agentContext.GetComponent<DroneRoot>().OnGetNewTask += BrokenState_OnGetNewTask;
            _animator = _agentContext.GetComponentInChildren<Animator>();
        }

        private void BrokenState_OnGetNewTask(object sender, EventArgs e)
        {
            //Ignore new task due to broken
        }

        public void Enter()
        {
            _animator.CrossFade(IdleAnimationHash, 0f);
        }

        public void Handle()
        {

        }

        public void Exit()
        {
            
        }
    }
}
