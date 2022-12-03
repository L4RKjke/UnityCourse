using UnityEngine;
using UnityEngine.UI;

public class SceneSettings : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private RawImage _backgroundImage;
    [SerializeField] private Backgraunds _backgrounds; 

    private void Start()
    {
        Time.timeScale = 1.0f;
        _audioSource.volume = PlayerPrefs.GetFloat(AllStrings.MusicVolume);
        Sprite _texture = _backgrounds.Backgrounds[PlayerPrefs.GetInt(AllStrings.CurrentBackground)].Image;
        _backgroundImage.texture = _texture.texture;
    }
}