using UnityEngine;
using UnityEngine.Events;

public class SwordTrigger : MonoBehaviour
{
    public UnityAction<Sword> SwordHittedAction;
    public UnityAction MissSwordAction;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.TryGetComponent<SwordTriggerLine>(out _))
        {
            SwordHittedAction?.Invoke(collider.transform.parent.GetComponent<Sword>());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        MissSwordAction?.Invoke();
    }
}