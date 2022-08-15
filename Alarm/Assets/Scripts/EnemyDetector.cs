using UnityEngine;

public class EnemyDetector : MonoBehaviour
{
    [SerializeField] private GameObject _player;

<<<<<<< Updated upstream
    private void Update()
    {
        if (_isSomebodyIn)
        {
            _sirena.ActivateAlarm();
        }
        else
            _sirena.DeactivateAlarm();
    }
=======
    public bool IsSomebodyIn { get; private set; } = false;
>>>>>>> Stashed changes

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IsSomebodyIn = (collision.TryGetComponent(out Character player));
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        IsSomebodyIn = !(collision.TryGetComponent(out Character player));
    }
}
