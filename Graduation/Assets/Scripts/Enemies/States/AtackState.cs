public class AtackState : State
{
    private Enemy _enemy;

    private void OnEnable()
    {
        _enemy = GetComponent<Enemy>();
        _enemy.StartShooting();
    }

    private void OnDisable()
    {
        _enemy.StopShooting();
    }
}