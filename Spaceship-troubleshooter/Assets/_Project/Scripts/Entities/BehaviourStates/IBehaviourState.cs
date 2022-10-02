namespace Assets._Project.Scripts.Entities
{
    public interface IBehaviourState
    {
        void Enter();
        void Handle();
        void Exit();
    }
}