using Assets._Project.Scripts.Ship;
using UnityEngine;

namespace Assets._Project.Scripts.Entities.BehaviourStates
{
    public class FixingState : IBehaviourState
    {
        private EntityStateMachine _entityStateMachine;
        private DroneModel _droneModel;
        private Trouble _troubleToFix;
        private Animator _animator;
        private DroneRoot _agentContext;

        private float _curFixTime;

        private static readonly int FixingAimationHash = Animator.StringToHash("Fixing");

        public FixingState(GameObject agentContext, EntityStateMachine stateMachine)
        {
            _entityStateMachine = stateMachine;
            _droneModel = agentContext.GetComponent<DroneRoot>().DroneModel;

            _troubleToFix = agentContext.GetComponent<Trouble>();
            _agentContext = agentContext.GetComponent<DroneRoot>();
            _animator = agentContext.GetComponent<Animator>();

            _agentContext.OnGetNewTask += FixingState_OnGetNewTask; ;
        }

        private void FixingState_OnGetNewTask(object sender, System.EventArgs e)
        {
            //Ignore new task
        }

        public void Enter()
        {
            _curFixTime = _droneModel.FixingTroubleTime;
            _animator.CrossFade(FixingAimationHash, 0f);
        }

        public void Handle()
        {
            _curFixTime -= Time.deltaTime;
            if(_curFixTime <= 0)
            {
                _troubleToFix.SolveTrouble();
                _droneModel.Upgrade();
                _agentContext.Damage();
                _entityStateMachine.Enter<IdleState>();
            }
        }

        public void Exit()
        {
            _curFixTime = 0;
        }
    }
}
