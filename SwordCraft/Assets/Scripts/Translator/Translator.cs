using UnityEngine;

public class Translator : MonoBehaviour
{
    private static string _currentLanguage = "en";

    private static string[,] _languages =
    {
        {
        "отличный меч!",
        "очистить" + "\n" + "грязь",
        "убрать" + "\n" + "ржавчину",
        "изменить" + "\n" + "цвет",
        "Вы получили новую рукоять!"
        },
        {
        "aferin sana!",
        "paspasla",
        "pas",
        "boya",
        "Yeni bir tutacagin var!"
        },
        {
        "nice sword!",
        "clean dirt",
        "clean rust",
        "paint",
        "You got a new handle!"
        }
    };


    public static string Translate(int id, string lang)
    {
        string _resultString = "...";

        _currentLanguage = lang;

        if (_currentLanguage == "ru")
        {
            _resultString = _languages[0, id];
        }
        else if (_currentLanguage == "tr")
        {
            _resultString = _languages[1, id];
        }
        else
        {
            _resultString = _languages[2, id];
        }

        return _resultString;
    }
}
