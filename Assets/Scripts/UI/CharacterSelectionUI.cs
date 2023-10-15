using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharacterSelectionUI : NetworkBehaviour
{
    [SerializeField] private GameData _gameData;
    [SerializeField] private Character[] _characters;
    [SerializeField] private Button[] _buttons;
    [SerializeField] private TMP_Text[] _texts;

    public void SelectCharacter(int index)
    {
        var id = NetworkManager.LocalClientId;

        _gameData.Players[id] = _characters[index];
        SetButtonColors(index);
        ToggleTexts(index, id);
    }

    void SetButtonColors(int index)
    {
        for (int i = 0; i < _buttons.Length; i++)
        {
            if (i != index) _buttons[index].image.color = Color.white;
            else _buttons[index].image.color = Color.red;
        }
    }

    void ToggleTexts(int index, ulong id)
    {
        for (int i = 0; i < _texts.Length; i++)
        {
            if (i == index) _texts[index].text = $"P{id.ToString() + 1}";
            
            _buttons[index].enabled = (i == index);            
        }
    }

    void ToggleTooltip(UnityEngine.EventSystems.BaseEventData data)
    {

    }
}
