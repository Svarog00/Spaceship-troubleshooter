using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Assets._Project.Scripts.Entities
{
    public class EntityStateMachine
    {
        private IBehaviorState _currentState;
        private Dictionary<Type, IBehaviorState> _states;

        public void Work()
        {
            _currentState.Handle();
        }

        public void Enter<TState>() where TState : class, IBehaviorState
        {
            _currentState = ChangeState<TState>();
            _currentState.Enter();
        }

        public TState ChangeState<TState>() where TState : class, IBehaviorState
        {
            _currentState?.Exit();
            return _states[typeof(TState)] as TState;
        }
    }
}
