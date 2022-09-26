using UnityEngine;
using UnityEngine.UI;

abstract public class Healthbar : MonoBehaviour
{
    [SerializeField] private Slider _slider;

    protected Slider Slider => _slider;

    abstract public void ChangeHealthbar(float value);
        
}