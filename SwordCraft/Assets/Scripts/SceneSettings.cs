using UnityEngine;
using UnityEngine.UI;

public class SceneSettings : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private RawImage _backgroundImage;
    

    private void Start()
    {
        Time.timeScale = 1.0f;
        _audioSource.volume = PlayerPrefs.GetFloat("MusicVolume");
        Texture _texture = PrefabContainer.Backgrounds[PlayerPrefs.GetInt("CurrentBackground")];
        _backgroundImage.texture = _texture;
    }
}