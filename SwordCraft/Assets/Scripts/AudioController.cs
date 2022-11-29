using UnityEngine;
using UnityEngine.UI;

public class AudioController : MonoBehaviour
{
    [SerializeField] private Slider _sliderObj;
    [SerializeField] private AudioSource _music;

    public float Volume => _sliderObj.value;

    private void Start()
    {
        float volume = PlayerPrefs.GetFloat("MusicVolume");
        _music.volume = volume;
        _sliderObj.value = volume;
    }

    public void OnValumeChanged()
    {
        _music.volume = _sliderObj.value;
    }
}