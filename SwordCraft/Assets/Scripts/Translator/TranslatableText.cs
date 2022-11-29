using Agava.YandexGames;
using System.Collections;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]

public class TranslatableText : MonoBehaviour
{
    [SerializeField] private int _textId;

    private void Awake()
    {
        YandexGamesSdk.CallbackLogging = true;
    }

    public IEnumerator Start()
    {
        yield return YandexGamesSdk.Initialize();

        GetComponent<TextMeshProUGUI>().text = Translator.Translate(_textId, YandexGamesSdk.Environment.i18n.lang.ToString());
    }
}