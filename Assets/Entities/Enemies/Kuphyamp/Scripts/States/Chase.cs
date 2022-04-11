using UnityEngine;

namespace Entities.Enemies.Kuphyamp.Scripts.States
{
    public class Chase : IState
    {
        public Chase(Kuphyamp context) => _context = context;
        private Kuphyamp _context;
        
        public void OnStateEnter() => _context.NavigatorAgent.isStopped = false;
        public void OnStateUpdate() => _context.NavigatorAgent.SetDestination(_context.ChaseTarget.position);
        public void OnStateExit(){}

        public bool TrySwitchState(out IState newState)
        {
            newState = null;
            if (!_context.IsSightOfViewTriggered) newState = new Patrol(_context);
            else if (_context.IsAttackRangeTriggered) newState = new Attack(_context);
            return newState != null;
        }
    }
}
