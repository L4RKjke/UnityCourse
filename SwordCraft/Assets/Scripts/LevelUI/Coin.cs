using DG.Tweening;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private float _rotateSpeed = 30;

    private void Update()
    {
        transform.Rotate(0, (Time.deltaTime* _rotateSpeed), 0.0f, Space.Self);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<Sword>(out Sword sword))
        {
            sword.OnCoinTrigger();
            transform.DOScale(0.5f, 0.5f);
            transform.DOJump(transform.position + new Vector3(1, 2f, 1), 0.6f, 1, 1f).OnComplete(() => gameObject.SetActive(false));
        }
    }
}
