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
    [SerializeField] private TMP_Text _potionsNumber;
    private float _healthBarTarget;

    [Header("Abilities")]
    [SerializeField] private Image _attackCooldown;
    [SerializeField] private TMP_Text _attackNumber;
    [SerializeField] private Image _specialCooldown;
    [SerializeField] private TMP_Text _specialNumber;
    [SerializeField] private Image _ultimateCooldown;
    [SerializeField] private TMP_Text _ultimateNumber;
    [SerializeField] private Image _dashCooldown;
    [SerializeField] private TMP_Text _dashNumber;

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
            case UIElement.Health:
                _healthBarTarget = current / max;
                _healthNumber.text = $"{(int)current}/{(int)max}";
                break;

            case UIElement.Potion:
                _potionsNumber.text = cdNumber;
                break;

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
        }
    }
}
