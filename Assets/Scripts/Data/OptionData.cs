using UnityEngine;

[CreateAssetMenu(fileName = "OptionData", menuName = "Data/Option Data")]
public class OptionData : ScriptableObject
{
    public float MusicVolume;
    public float EffectVolume;
    public int TargetFPS;
    public bool StaticCamera;
    public bool DamageNumbers;
    public bool ControllerInput;

    [SerializeField] private VoidEventChannel _optionChangeEvent;

    public void ApplyChanges()
    {
        _optionChangeEvent.RaiseVoidEvent();
    }
}
