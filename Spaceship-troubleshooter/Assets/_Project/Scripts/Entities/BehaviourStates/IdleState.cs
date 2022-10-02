using System;
using UnityEditorInternal;
using UnityEngine;

namespace Assets._Project.Scripts.Entities.BehaviourStates
{
    public class IdleState : IBehaviourState
    {
        private GameObject _agentContext;
        private EntityStateMachine _stateMachine;

        public IdleState(GameObject agentContext, EntityStateMachine stateMachine)
        {
            _agentContext = agentContext;
            _stateMachine = stateMachine;

            _agentContext.GetComponent<DroneRoot>().OnGetNewTask += MovingToTroubleState_OnGetNewTask;
        }

        private void MovingToTroubleState_OnGetNewTask(object sender, EventArgs e)
        {
            
        }

        public void Enter()
        {
            
        }

        public void Exit()
        {
            
        }

        public void Handle()
        {
            
        }
    }
}
