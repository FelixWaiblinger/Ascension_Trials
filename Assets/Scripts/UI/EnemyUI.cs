using UnityEngine;
using UnityEngine.UI;

public class EnemyUI : MonoBehaviour
{
    [SerializeField] private Image _healthBar;
    [SerializeField] private float _healthAnimSpeed;
    private float _healthBarTarget = 1;

    void Update()
    {
        if (_healthBar.fillAmount == _healthBarTarget) return;
        
        _healthBar.fillAmount = Mathf.MoveTowards(
            _healthBar.fillAmount,
            _healthBarTarget,
            _healthAnimSpeed * Time.deltaTime
        );
    }

    public void UpdateHealth(float current, float max)
    {
        _healthBarTarget = current / max;
    }
}
