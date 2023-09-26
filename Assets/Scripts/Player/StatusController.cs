using UnityEngine;

public class StatusController : MonoBehaviour, IDamagable, IHealable
{
    [SerializeField] private VoidEventChannel _deathEvent;
    [SerializeField] private PlayerUI _hud;
    [SerializeField] private int _healthPotions;
    [SerializeField] private float _healDuration;
    private Animator _animator;
    private float _armor;
    private float _maxHealth;
    private float _currentHealth;
    private float _healDurationTimer;

    #region SETUP

    void OnEnable()
    {
        InputReader.healEvent += Potion;
    }

    void OnDisable()
    {
        InputReader.healEvent -= Potion;
    }
    
    void Start()
    {
        _animator = GetComponentInChildren<Animator>();
        _currentHealth = _maxHealth;
    }

    public void Init(float health, float armor)
    {
        _maxHealth = health;
        _armor = armor;
    }

    #endregion

    public void Damage(Vector3 info)
    {
        _currentHealth = Mathf.Clamp(_currentHealth - info.x, 0, _maxHealth);
        _hud.UpdateUIElement(UIElement.Health, _currentHealth, _maxHealth);

        if (_currentHealth <= 0)
        {
            _deathEvent.RaiseVoidEvent();
            _animator.SetTrigger("death");
        }
    }

    public void Heal(Vector3 info)
    {
        _currentHealth = Mathf.Clamp(_currentHealth + info.x, 0, _maxHealth);
    }

    #region EVENT

    void Potion()
    {
        if (_healthPotions <= 0) return;

        if (_healDurationTimer > 0) return;

        _healDurationTimer = _healDuration;
        _animator.SetTrigger("potion");
    }

    #endregion
}
