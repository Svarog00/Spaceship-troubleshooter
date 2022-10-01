namespace Assets._Project.Scripts.Entities
{
    public interface IBehaviorState
    {
        void Enter();
        void Handle();
        void Exit();
    }
}