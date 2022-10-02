using Assets._Project.Scripts.Ship;
using UnityEngine;

namespace Assets._Project.Scripts.Entities.BehaviourStates
{
    public class FixingState : IBehaviourState
    {
        private EntityStateMachine _entityStateMachine;
        private DroneModel _droneModel;
        private Trouble _troubleToFix;

        public FixingState(GameObject agentContext, EntityStateMachine stateMachine)
        {
            _entityStateMachine = stateMachine;
            _droneModel = agentContext.GetComponent<DroneRoot>().DroneModel;
            _troubleToFix = agentContext.GetComponent<Trouble>();

            agentContext.GetComponent<DroneRoot>().OnGetNewTask += FixingState_OnGetNewTask; ;
        }

        private void FixingState_OnGetNewTask(object sender, System.EventArgs e)
        {
            
        }

        public void Enter()
        {
            //TODO: Start fixing animation
        }

        public void Handle()
        {
            //TODO: Fixing trouble logic

        }

        public void Exit()
        {
            
        }

    }
}
