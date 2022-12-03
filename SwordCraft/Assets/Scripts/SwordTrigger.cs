using UnityEngine;
using UnityEngine.Events;

public class SwordTrigger : MonoBehaviour
{
    public UnityAction SwordHittedAction;
    public UnityAction MissSwordAction;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.TryGetComponent<SwordTriggerLine>(out _))
        {
            SwordHittedAction?.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        MissSwordAction?.Invoke();
    }
}