using UnityEngine;

namespace Entities.Enemies.Kuphyamp.Scripts.States
{
    public class Patrol : IState
    {
        public Patrol(Kuphyamp context) => _context = context;
        
        private Kuphyamp _context;
        
        private Vector3 _currentTarget;

        public void OnStateEnter()
        {
            _currentTarget = _context.PatrolPoints[_context.LastPatrolPoint++];
            _context.NavigatorAgent.isStopped = false;
            _context.NavigatorAgent.speed = _context.WalkSpeed;
            _context.NavigatorAgent.SetDestination(_currentTarget);
        }

        public void OnStateUpdate(){}

        public void OnStateExit()
        {
            _context.NavigatorAgent.isStopped = true;
            if (_context.LastPatrolPoint == _context.PatrolPoints.Count) _context.LastPatrolPoint = 0;
        }

        public bool TrySwitchState(out IState newState)
        {
            newState = null;
            if (_context.IsAttackRangeTriggered) newState = new Attack(_context);
            else if (_context.IsSightOfViewTriggered) newState = new Chase(_context);
            else if (!_context.NavigatorAgent.hasPath) newState = new Idle(_context);
            
            return newState != null;
        }
    }
}
