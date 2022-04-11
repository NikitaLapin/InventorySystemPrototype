namespace Entities.Enemies.Kuphyamp.Scripts.States
{
    public class Attack : IState
    {
        public Attack(Kuphyamp context) => _context = context;

        private Kuphyamp _context;
        
        public void OnStateEnter()
        {
            throw new System.NotImplementedException();
        }

        public void OnStateUpdate()
        {
            throw new System.NotImplementedException();
        }

        public void OnStateExit()
        {
            throw new System.NotImplementedException();
        }

        public bool TrySwitchState(out IState newState)
        {
            throw new System.NotImplementedException();
        }
    }
}
