using UnityEngine;

abstract public class State : MonoBehaviour
{
    [SerializeField] Transition[] _transitions;

    protected Player Target { get; private set; }

    protected Enemy Enemy { get; private set; }

    public void Enter(Player target)
    {
        enabled = true;
        Target = target;

        foreach (var transition in _transitions)
        {
            transition.Init(Target);
            transition.enabled = true;
        }
    }

    public void Exit()
    {

        foreach (var transition in _transitions)
            transition.enabled = false;

        enabled = false;
    }

    public State GetState()
    {
        foreach (var transition in _transitions)
        {
            if (transition.NeedTransit)
                return transition.TargetState;
        }

        return null;
    }
}