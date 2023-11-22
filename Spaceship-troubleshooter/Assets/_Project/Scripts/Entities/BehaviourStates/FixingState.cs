using Assets._Project.Scripts.Ship;
using UnityEngine;

namespace Assets._Project.Scripts.Entities.BehaviourStates
{
    public class FixingState : IBehaviourState
    {
        private DroneRoot _agentContext;
        private DroneModel _droneModel;
        private EntityStateMachine _entityStateMachine;
        private Trouble _troubleToFix;

        private Animator _animator;

        private float _curFixTime;

        private readonly int FixingAimationHash = Animator.StringToHash("Fixing");

        public FixingState(GameObject agentContext, EntityStateMachine stateMachine)
        {
            _entityStateMachine = stateMachine;
            _droneModel = agentContext.GetComponent<DroneRoot>().DroneModel;

            _agentContext = agentContext.GetComponent<DroneRoot>();
            _animator = agentContext.GetComponentInChildren<Animator>();

            _agentContext.OnGetNewTask += FixingState_OnGetNewTask; ;
        }

        private void FixingState_OnGetNewTask(object sender, System.EventArgs e)
        {
            //Ignore new task
        }

        public void Enter()
        {
            _troubleToFix = _agentContext.TroubleObject.GetComponent<Trouble>();
            _curFixTime = _droneModel.FixingTroubleTime;
            _animator.CrossFade(FixingAimationHash, 0f);
        }

        public void Handle()
        {
            _curFixTime -= Time.deltaTime;
            var percentageOfCompletion = (1 - (_curFixTime / _droneModel.FixingTroubleTime)) * 100;
            _troubleToFix.SetHealth(percentageOfCompletion);

            if(_curFixTime <= 0)
            {
                _troubleToFix.SolveTrouble(_agentContext);
                _droneModel.Upgrade();
                _entityStateMachine.Enter<IdleState>();
            }
        }

        public void Exit()
        {
            _curFixTime = 0;
        }
    }
}
