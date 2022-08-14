using UnityEngine;

public class EnemyDetector : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private Sirena _sirena;
    private bool _isSomebodyIn = false;

    private void Update()
    {

        if (_isSomebodyIn)
        {
            _sirena.ActivateAlarm();
        }
        else
            _sirena.DeactivateAlarm();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _isSomebodyIn = collision.TryGetComponent(out Character player);    
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _isSomebodyIn = !collision.TryGetComponent(out Character player);
    }
}
