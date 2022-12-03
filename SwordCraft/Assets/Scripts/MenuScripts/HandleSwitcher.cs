using UnityEngine;
using UnityEngine.UI;

public class HandleSwitcher : MonoBehaviour
{
    [SerializeField] private Handle[] _handles;
    [SerializeField] private Button[] _buttons;
    [SerializeField] private Image[] _buttonImages;

    void Start()
    {
        for (int i = 1; i < _handles.Length; i++)
        {
            _buttons[i].interactable = false;
        }

        for (int i = 0; i < _buttons.Length; i++)
        {
            _buttonImages[i].sprite = _handles[i].Image;
        }

        for (int i = 1; i < PlayerPrefs.GetInt(AllStrings.MaxHandle) +1; i++)
        {
            _buttons[i].interactable = true;
        }
    }

    public void OnHandleClick(int buttonId)
    {
        if (buttonId <= PlayerPrefs.GetInt(AllStrings.MaxHandle))
            PlayerPrefs.SetInt(AllStrings.CurrentHandle, buttonId);
    }
}
