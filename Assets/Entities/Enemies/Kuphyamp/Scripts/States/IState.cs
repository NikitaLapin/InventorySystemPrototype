namespace Entities.Enemies.Kuphyamp.Scripts.States
{
    public interface IState
    {
        public void OnStateEnter();
        public void OnStateUpdate();
        public void OnStateExit();
        public bool TrySwitchState(out IState newState);
    }
}
