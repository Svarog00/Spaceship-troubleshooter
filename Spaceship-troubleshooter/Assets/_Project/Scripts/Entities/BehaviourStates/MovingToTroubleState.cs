using UnityEngine;

namespace Assets._Project.Scripts.Entities.BehaviourStates
{
    public class MovingToTroubleState : IBehaviourState
    {
        private EntityStateMachine _stateMachine;
        private EntityMovement _movement;
        private GameObject _agentContext;
        private Vector3 _targetPosition;
        private Animator _animator;

        private readonly int WalkAnimationHash = Animator.StringToHash("Walk");

        public MovingToTroubleState(GameObject agentContext, EntityStateMachine stateMachine)
        {
            _agentContext = agentContext;
            _stateMachine = stateMachine;

            _animator = _agentContext.GetComponentInChildren<Animator>();
            _movement = _agentContext.GetComponent<EntityMovement>();
            _agentContext.GetComponent<DroneRoot>().OnGetNewTask += MovingToTroubleState_OnGetNewTask;
        }

        private void MovingToTroubleState_OnGetNewTask(object sender, System.EventArgs e)
        {
            Enter();
        }

        public void Enter()
        {
            _targetPosition = _agentContext.GetComponent<DroneRoot>().TroubleObject.transform.position;
            _movement.SetTargetPosition(_targetPosition);
            _movement.CanMove = true;
            _animator.CrossFade(WalkAnimationHash, 0f);
        }

        public void Handle()
        {
            if(Vector2.Distance(_agentContext.transform.position, _targetPosition) <= 0.15f)
            {
                _stateMachine.Enter<FixingState>();
            }
        }

        public void Exit()
        {
            _movement.CanMove = false;
        }

    }
}
