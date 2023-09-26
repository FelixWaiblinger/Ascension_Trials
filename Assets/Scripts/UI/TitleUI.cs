using UnityEngine;

public class TitleUI : MonoBehaviour
{
    [SerializeField] private Canvas _titleCanvas;
    [SerializeField] private SettingsUI _settings;
    [SerializeField] private Transform _buttons;
    [SerializeField] private float _bobbingSpeed;
    private SettingsUI _settingsInstance;
    private float _bobbingDirection = 1, _bobbingTimer = 0;

    void Update()
    {
        if (!_titleCanvas.enabled && !_settingsInstance)
            _titleCanvas.enabled = true;

        Bobbing();
    }

    void Bobbing()
    {
        if (_bobbingTimer >= 2)
        {
            _bobbingDirection *= -1;
            _bobbingTimer = 0;
        }

        _bobbingTimer += Time.deltaTime;
        
        _buttons.Translate(_bobbingDirection * _bobbingSpeed * Time.deltaTime * Vector3.up);
    }

    public void Settings()
    {
        _titleCanvas.enabled = false;
        _settingsInstance = Instantiate(_settings);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
