using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public enum UIElement
{
    Attack, Special, Ultimate, Dash, Health, Potion
}

public class PlayerUI : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] private Image _healthBar;
    [SerializeField] private TMP_Text _healthNumber;
    [SerializeField] private float _healthSmoothness;
    [SerializeField] private Image _potionsIcon;
    [SerializeField] private TMP_Text _potionsNumber;
    private float _healthBarTarget = 1;

    [Header("Attack")]
    [SerializeField] private Image _attackIcon;
    [SerializeField] private Image _attackCooldown;
    [SerializeField] private TMP_Text _attackNumber;

    [Header("Special")]
    [SerializeField] private Image _specialIcon;
    [SerializeField] private Image _specialCooldown;
    [SerializeField] private TMP_Text _specialNumber;

    [Header("Ultimate")]
    [SerializeField] private Image _ultimateIcon;
    [SerializeField] private Image _ultimateCooldown;
    [SerializeField] private TMP_Text _ultimateNumber;

    [Header("Dash")]
    [SerializeField] private Image _dashIcon;
    [SerializeField] private Image _dashCooldown;
    [SerializeField] private TMP_Text _dashNumber;

    public void Init(float health, Dictionary<Slot, Ability> abilities)
    {
        _healthNumber.text = $"{(int)health}/{(int)health}";
        _attackIcon.sprite = abilities[Slot.Attack].Icon;
        _specialIcon.sprite = abilities[Slot.Special].Icon;
        _ultimateIcon.sprite = abilities[Slot.Ultimate].Icon;
        _dashIcon.sprite = abilities[Slot.Dash].Icon;
    }

    void Update()
    {
        if (_healthBar.fillAmount != _healthBarTarget)
        {
            _healthBar.fillAmount = Mathf.MoveTowards(
                _healthBar.fillAmount,
                _healthBarTarget,
                _healthSmoothness
            );
        }
    }

    public void UpdateUIElement(UIElement element, float current, float max)
    {
        var cdNumber = "";
        if (current == max) cdNumber = max.ToString();
        else if (current > 0) cdNumber = ((int)current+1).ToString();

        switch (element)
        {
            case UIElement.Attack:
                _attackCooldown.fillAmount = current / max;
                _attackNumber.text = cdNumber;
                break;

            case UIElement.Special:
                _specialCooldown.fillAmount = current / max;
                _specialNumber.text = cdNumber;
                break;

            case UIElement.Ultimate:
                _ultimateCooldown.fillAmount = current / max;
                _ultimateNumber.text = cdNumber;
                break;

            case UIElement.Dash:
                _dashCooldown.fillAmount = current / max;
                _dashNumber.text = cdNumber;
                break;

            case UIElement.Health:
                _healthBarTarget = current / max;
                _healthNumber.text = $"{(int)current}/{(int)max}";
                break;

            case UIElement.Potion:
                _potionsNumber.text = cdNumber;
                break;
        }
    }
}
