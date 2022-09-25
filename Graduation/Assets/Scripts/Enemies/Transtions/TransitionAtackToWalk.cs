using UnityEngine;

public class TransitionAtackToWalk : Transition
{
    [SerializeField] private float _spreadRange;
    [SerializeField] private float _atackRange;
    [SerializeField] private Enemy _enemy;

    private void Start()
    {
        _atackRange += Random.Range(-_spreadRange, _spreadRange);
    }


    private void Update()
    {
        if (Target != null)
            if (Vector2.Distance(_enemy.transform.position, Target.transform.position) >= _atackRange)
            NeedTransit = true;
    }
}