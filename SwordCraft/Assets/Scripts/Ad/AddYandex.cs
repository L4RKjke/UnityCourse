using Agava.YandexGames;
using System;
using System.Collections;
using UnityEngine;
using static Agava.YandexGames.YandexGamesEnvironment;

public class AddYandex : MonoBehaviour
{
    [SerializeField] private AudioSource _audio;

    private Action OnOpenCallback;
    private bool _isAddClosed = false;

    private void Awake()
    {
        YandexGamesSdk.CallbackLogging = true;
    }

    public IEnumerator Start()
    {
        yield return YandexGamesSdk.Initialize();

        ShowAd();
    }

    public void OnAdClosed(bool isClosed)
    {
        _isAddClosed = isClosed;
        _audio.Play();
        Time.timeScale = 1;
    }

    public void ShowAd()
    {
        Time.timeScale = 0;
        _audio.Pause();
        InterstitialAd.Show(OnOpenCallback, isClosed => OnAdClosed(isClosed));
    }
}
