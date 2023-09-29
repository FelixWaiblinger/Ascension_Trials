using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SettingsUI : MonoBehaviour
{
    [SerializeField] private OptionData _options;

    [SerializeField] private Slider _musicVolume;
    [SerializeField] private Slider _effectVolume;
    [SerializeField] private TMP_InputField _targetFPS;
    [SerializeField] private Toggle _staticCamera;
    [SerializeField] private Toggle _damageNumbers;
    [SerializeField] private Image _controllerScheme;
    [SerializeField] private Image _keyboardScheme;

    #region SETUP

    void Awake()
    {
        _musicVolume.value = _options.MusicVolume;
        _effectVolume.value = _options.EffectVolume;
        _targetFPS.text = _options.TargetFPS.ToString();
        _staticCamera.isOn = _options.StaticCamera;
        _damageNumbers.isOn = _options.DamageNumbers;
        _controllerScheme.color *= new Color(1, 1, 1, _options.ControllerInput ? 1 : 0);
        _controllerScheme.color *= new Color(1, 1, 1, _options.ControllerInput ? 0 : 1);
    }

    void OnEnable()
    {
        _musicVolume.onValueChanged.AddListener(OnMusicVolume);
        _effectVolume.onValueChanged.AddListener(OnEffectVolume);
        _targetFPS.onValueChanged.AddListener(OnTargetFPS);
        _staticCamera.onValueChanged.AddListener(OnStaticCamera);
        _damageNumbers.onValueChanged.AddListener(OnDamageNumbers);
    }

    void OnDisable()
    {
        _musicVolume.onValueChanged.RemoveAllListeners();
        _effectVolume.onValueChanged.RemoveAllListeners();
        _targetFPS.onValueChanged.RemoveAllListeners();
        _staticCamera.onValueChanged.RemoveAllListeners();
        _damageNumbers.onValueChanged.RemoveAllListeners();
    }

    #endregion
    
    public void OnMusicVolume(float value)
    {
        _options.MusicVolume = value;
    }

    public void OnEffectVolume(float value)
    {
        _options.EffectVolume = value;
    }

    public void OnTargetFPS(string value)
    {
        _options.TargetFPS = int.Parse(value);
    }

    public void OnStaticCamera(bool value)
    {
        _options.StaticCamera = value;
    }

    public void OnDamageNumbers(bool value)
    {
        _options.DamageNumbers = value;
    }

    public void OnInput()
    {
        _options.ControllerInput = !_options.ControllerInput;
    }

    public void Close()
    {
        Destroy(gameObject);
    }
}
