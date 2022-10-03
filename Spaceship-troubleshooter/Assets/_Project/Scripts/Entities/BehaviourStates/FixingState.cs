using Assets._Project.Scripts.Ship;
using UnityEngine;

namespace Assets._Project.Scripts.Entities.BehaviourStates
{
    public class FixingState : IBehaviourState
    {
        private EntityStateMachine _entityStateMachine;
        private DroneModel _droneModel;
        private Trouble _troubleToFix;
        private DroneRoot _agentContext;

        private float _curFixTime;

        public FixingState(GameObject agentContext, EntityStateMachine stateMachine)
        {
            _entityStateMachine = stateMachine;
            _agentContext = agentContext.GetComponent<DroneRoot>();
            _droneModel = _agentContext.DroneModel;
            _troubleToFix = agentContext.GetComponent<Trouble>();

            _agentContext.OnGetNewTask += FixingState_OnGetNewTask; ;
        }

        private void FixingState_OnGetNewTask(object sender, System.EventArgs e)
        {
            //Ignore new task
        }

        public void Enter()
        {
            _curFixTime = _droneModel.FixingTroubleTime;
            //TODO: Start fixing animation
        }

        public void Handle()
        {
            _curFixTime -= Time.deltaTime;
            if(_curFixTime <= 0)
            {
                _troubleToFix.SolveTrouble();
                _droneModel.Upgrade();
                NewMethod();
                _entityStateMachine.ChangeState<IdleState>();
            }
        }

        private void NewMethod()
        {
            _agentContext.Damage();
        }

        public void Exit()
        {
            _curFixTime = 0;
        }
    }
}
