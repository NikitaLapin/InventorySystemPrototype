using UnityEngine;

namespace Entities.Enemies.Kuphyamp.Scripts.States
{
    public class Idle : IState
    {
        public Idle(Kuphyamp context) => _context = context;
        
        private Kuphyamp _context;
        private float _timer;
        
        public void OnStateEnter() => _timer = 0f;
        public void OnStateUpdate() => _timer += Time.deltaTime;

        public void OnStateExit(){}

        public bool TrySwitchState(out IState newState)
        {
            newState = null;
            if (_timer >= _context.PatrolPointIdleTime) newState = new Patrol(_context);
            if (_context.IsSightOfViewTriggered) newState = new Chase(_context);
            
            return newState != null;
        }
    }
}