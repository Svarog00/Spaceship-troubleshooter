using System;
using UnityEditorInternal;
using UnityEngine;

namespace Assets._Project.Scripts.Entities.BehaviourStates
{
    public class IdleState : IBehaviourState
    {
        private GameObject _agentContext;
        private DroneRoot _droneRoot;
        private EntityStateMachine _stateMachine;

        public IdleState(GameObject agentContext, EntityStateMachine stateMachine)
        {
            _agentContext = agentContext;
            _stateMachine = stateMachine;
            _droneRoot = _agentContext.GetComponent<DroneRoot>();
            _droneRoot.OnGetNewTask += IdleState_OnGetNewTask; ;
        }

        private void IdleState_OnGetNewTask(object sender, EventArgs e)
        {
            if(Vector2.Distance(_agentContext.transform.position, _droneRoot.TroubleObject.transform.position) <= 0.15f)
            {
                _stateMachine.ChangeState<FixingState>();
            }
            else
            {
                _stateMachine.ChangeState<MovingToTroubleState>();
            }
        }

        public void Enter()
        {
            
        }

        public void Handle()
        {

        }

        public void Exit()
        {
            
        }
    }
}
