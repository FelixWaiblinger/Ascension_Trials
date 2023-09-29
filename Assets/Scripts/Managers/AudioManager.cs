using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private IntEventChannel _audioEvent;
    [SerializeField] private OptionData _options;
    [SerializeField] private AudioClip[] _themes;
    [SerializeField] private float _fadeSpeed;
    private AudioSource _themePlayer;
    private int _nextClip = -1;

    #region SETUP

    void Awake()
    {
        DontDestroyOnLoad(gameObject);

        _themePlayer = GetComponent<AudioSource>();
        _themePlayer.clip = _themes[0];
        _themePlayer.Play();
    }

    void OnEnable()
    {
        _audioEvent.OnIntEventRaised += PlayTheme;
    }

    void OnDisable()
    {
        _audioEvent.OnIntEventRaised -= PlayTheme;
    }

    #endregion

    void Update()
    {
        // no music change requested
        if (_nextClip == -1) return;

        // music has changed -> fading in
        if (_nextClip == -2)
        {
            if (Fade(_fadeSpeed * Time.deltaTime))
                _nextClip = -1;
        }
        // music change requested -> fading out
        else if (Fade(-_fadeSpeed * Time.deltaTime))
        {
            _themePlayer.clip = _themes[_nextClip];
            _themePlayer.Play();
            _nextClip = -2;
        }
    }

    void PlayTheme(int themeIndex)
    {
        _nextClip = themeIndex;
    }

    bool Fade(float amount)
    {
        _themePlayer.volume = Mathf.Clamp(_themePlayer.volume + amount, 0, _options.MusicVolume);

        return _themePlayer.volume == 0 || _themePlayer.volume == _options.MusicVolume;
    }
}
