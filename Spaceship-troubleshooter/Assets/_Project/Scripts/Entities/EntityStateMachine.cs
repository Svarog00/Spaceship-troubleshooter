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
        public Dictionary<Type, IBehaviourState> States
        {
            get => _states;
            set => _states = value;
        }

        private IBehaviourState _currentState;
        private Dictionary<Type, IBehaviourState> _states;

        public void Work()
        {
            _currentState.Handle();
        }

        public void Enter<TState>() where TState : class, IBehaviourState
        {
            _currentState = ChangeState<TState>();
            _currentState.Enter();
        }

        public TState ChangeState<TState>() where TState : class, IBehaviourState
        {
            _currentState?.Exit();
            return _states[typeof(TState)] as TState;
        }
    }
}
