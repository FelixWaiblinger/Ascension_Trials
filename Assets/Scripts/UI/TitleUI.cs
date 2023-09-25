using UnityEngine;

public class TitleUI : MonoBehaviour
{
    [SerializeField] private Canvas _titleCanvas;
    [SerializeField] private SettingsUI _settings;
    private SettingsUI _settingsInstance;

    void Update()
    {
        if (!_titleCanvas.enabled && !_settingsInstance)
            _titleCanvas.enabled = true;
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
