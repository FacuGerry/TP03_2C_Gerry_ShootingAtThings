using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(Animator))]

public class NpcController : MonoBehaviour
{
    private Rigidbody _rb;
    private Animator _anim;
    [SerializeField] private EnemyDataSO _data;
    [SerializeField] private GameObject _player; // this should be received from a SO of the game settings
    private EnemyClasses _enemyClass;

    private List<EnemyStates> _states = new();
    private EnemyStates _currentState;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _anim = GetComponent<Animator>();

        _enemyClass = _data.enemyClass;

        // _states.Add(new StateIdle());
        // _states.Add(new StateShoot());
        // _states.Add(new StateRoam());
        // _states.Add(new StateFollow());
        // _states.Add(new StateDie());

        foreach (EnemyStates state in _states)
            state.Initialize(_anim, _rb, this);

        _currentState = FindState(StateTypeEnemy.Idle);
        _currentState.OnEnter();
    }

    private void Update()
    {
        LookForPlayer();
    }

    private IEnumerator Shooting()
    {
        yield return null;
    }

    private IEnumerator LaserShooting()
    {
        yield return null;
    }

    public void SwitchState(EnemyStates newState)
    {
        if (_currentState == newState)
            return;

        _currentState.OnExit();
        _currentState = newState;
        _currentState.OnEnter();
    }

    public EnemyStates FindState(StateTypeEnemy stateToFind)
    {
        foreach (EnemyStates state in _states)
            if (state.state == stateToFind)
                return state;

        return null;
    }

    private void LookForPlayer()
    {
        if (Vector3.Distance(transform.position, _player.transform.position) < _data.distanceToShoot)
        {
            Debug.Log("Player was located by " + gameObject.name, gameObject);
        }
    }
}