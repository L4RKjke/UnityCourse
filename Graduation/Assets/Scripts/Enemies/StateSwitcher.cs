using UnityEngine;

public class StateSwitcher : MonoBehaviour
{
    [SerializeField] private State _firstState;

    private Player _target;
    private State _currentState;

    public State Current => _currentState;

    private void Start()
    {
        _target = GetComponent<EnemyRed>().Target;
        Reset(_firstState);
    }

    private void Update()
    {
        if (_currentState == null)
        {
            return;
        }

        var nextState = _currentState.GetState();

        if (nextState != null)
        {
            Transit(nextState);
        }
    }

    public void Transit(State NewState)
    {
        if (_currentState != null)
            _currentState.Exit();

        _currentState = NewState;

        if (_currentState != null)
            _currentState.Enter(_target);
    }

    private void Reset(State startState)
    {
        _currentState = startState;

        if (_currentState != null)
            _currentState.Enter(_target);
    }
}
