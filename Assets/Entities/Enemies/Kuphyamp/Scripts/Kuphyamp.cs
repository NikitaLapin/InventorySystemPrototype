using System;
using System.Collections.Generic;
using Entities.Enemies.Kuphyamp.Scripts.States;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.AI;

namespace Entities.Enemies.Kuphyamp.Scripts
{
    [RequireComponent(typeof(CharacterController))]
    public class Kuphyamp : Enemy
    {
        #region SerializableFields

        [Header("Patrol fields")] 
        [SerializeField] private List<Transform> patrolPoints;
        [SerializeField] private float walkSpeed = 2f;
        [SerializeField] private float patrolPointIdleTime = 4f;

        [Header("Chase fields")] 
        [SerializeField] private float sightOfViewDistance = 2f;
        [SerializeField] private float chaseSightOfViewDistance = 1f;

        [Header("Attack fields")]
        [SerializeField] private float damage;
        [SerializeField] private float attackDistance;

        #endregion

        #region PublicGetters
        
        public bool IsSightOfViewTriggered { get; private set; }
        public bool IsAttackRangeTriggered { get; private set; }

        public int LastPatrolPoint { get; set; } = 0;
        public float WalkSpeed => walkSpeed;
        public float PatrolPointIdleTime => patrolPointIdleTime;
        public float SightOfViewDistance => sightOfViewDistance;
        public float ChaseSightOfViewDistance => chaseSightOfViewDistance;
        public float Damage => damage;
        public float AttackDistance => attackDistance;

        public CharacterController EnemyController { get; private set; }
        public NavMeshAgent NavigatorAgent { get; private set; }
        public List<Vector3> PatrolPoints => _patrolPointsPosition;
        public Transform Transform { get; private set; }
        public Transform ChaseTarget { get; private set; }
        public Transform AttackTarget { get; private set; }
        
        #endregion

        #region PrivateFields

        private IState _currentState;
        private List<Vector3> _patrolPointsPosition = new List<Vector3>();
        private TriggerScript _sightOfViewTrigger = null;
        private TriggerScript _attackRangeTrigger = null;

        #endregion

        #region MonoBehaviourMethods

        private void Awake()
        {
            EnemyController = GetComponent<CharacterController>();
            Transform = GetComponent<Transform>();
            NavigatorAgent = GetComponent<NavMeshAgent>();

            _sightOfViewTrigger = InitializeTrigger("SightOfViewTrigger");
            _sightOfViewTrigger.ChangeRange(SightOfViewDistance);
            
            _attackRangeTrigger = InitializeTrigger("AttackRangeTrigger");
            _attackRangeTrigger.ChangeRange(AttackDistance);
            
            SetUpPatrolPoints();
            
            _currentState = new Patrol(this);
            _currentState.OnStateEnter();
        }

        private void OnEnable()
        {
            _sightOfViewTrigger.TriggerChanged += OnSightOfViewTriggerChanged;
            _attackRangeTrigger.TriggerChanged += OnAttackRangeTriggerChanged;
        }

        private void OnDisable()
        {
            _sightOfViewTrigger.TriggerChanged -= OnSightOfViewTriggerChanged;
            _attackRangeTrigger.TriggerChanged -= OnAttackRangeTriggerChanged;
        }

        private void Update()
        {
            if(_currentState.TrySwitchState(out var newState)) SwitchState(newState);
            _currentState.OnStateUpdate();
        }

        #endregion
        
        #region EventHandlers

        private void OnSightOfViewTriggerChanged(bool isActive, Transform triggerTransform)
        {
            IsSightOfViewTriggered = isActive;
            if (isActive) _sightOfViewTrigger.ChangeRange(ChaseSightOfViewDistance);
            else _sightOfViewTrigger.ChangeRange(SightOfViewDistance);
            ChaseTarget = triggerTransform;
        }

        private void OnAttackRangeTriggerChanged(bool isActive, Transform triggerTransform)
        {
            IsAttackRangeTriggered = isActive;
            AttackTarget = triggerTransform;
        }

        #endregion

        #region PrivateMethods
        
        private void SwitchState(IState newState)
        {
            _currentState.OnStateExit();
            _currentState = newState;
            _currentState.OnStateEnter();
        }

        private void SetUpPatrolPoints()
        {
            if (patrolPoints.Count < 1) throw new ArgumentException("Enemy doesnt have enough patrol points");

            foreach (var patrolPoint in patrolPoints) _patrolPointsPosition.Add(patrolPoint.position);
        }

        private TriggerScript InitializeTrigger(string triggerName)
        {
            var triggerObject = new GameObject(triggerName);
            triggerObject.transform.SetParent(Transform);
            triggerObject.transform.position = Transform.position;
            return triggerObject.AddComponent<TriggerScript>();
        }

        #endregion
    }
}
