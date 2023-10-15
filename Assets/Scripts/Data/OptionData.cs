using UnityEngine;

[CreateAssetMenu(fileName = "OptionData", menuName = "Data/Option Data")]
[System.Serializable]
public class OptionData : ScriptableObject
{
    private float _musicVolume;
    public float MusicVolume
    {
        get { return _musicVolume; }
        set { _optionChangeEvent.RaiseVoidEvent(); _musicVolume = value; }
    }
    private float _effectVolume;
    public float EffectVolume
    {
        get { return _effectVolume; }
        set { _optionChangeEvent.RaiseVoidEvent(); _effectVolume = value; }
    }
    private int _targetFPS;
    public int TargetFPS
    {
        get { return _targetFPS; }
        set { _optionChangeEvent.RaiseVoidEvent(); _targetFPS = value; }
    }
    private bool _staticCamera;
    public bool StaticCamera
    {
        get { return _staticCamera; }
        set { _optionChangeEvent.RaiseVoidEvent(); _staticCamera = value; }
    }
    private bool _damageNumbers;
    public bool DamageNumbers
    {
        get { return _damageNumbers; }
        set { _optionChangeEvent.RaiseVoidEvent(); _damageNumbers = value; }
    }
    private bool _controllerInput;
    public bool ControllerInput
    {
        get { return _controllerInput; }
        set { _optionChangeEvent.RaiseVoidEvent(); _controllerInput = value; }
    }

    [SerializeField] private VoidEventChannel _optionChangeEvent;
}
