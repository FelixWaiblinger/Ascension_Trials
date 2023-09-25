using UnityEngine;

public class PlatformBobbing : MonoBehaviour
{
    [SerializeField] private float _bobbingSpeed;
    [SerializeField] private float _bobbingRangeMin;
    [SerializeField] private float _bobbingRangeMax;
    private Transform[] _platforms;
    private float[] _moveDirections;
    private float[] _bobbingTimers;

    void Start()
    {
        _platforms = new Transform[transform.childCount];
        _moveDirections = new float[_platforms.Length];
        _bobbingTimers = new float[_platforms.Length];

        for (int i = 0; i < _platforms.Length; i++)
        {
            _platforms[i] = transform.GetChild(i);
            _moveDirections[i] = Mathf.Sign(Random.Range(-1, 1));
        }
    }

    void Update()
    {
        var time = Time.deltaTime;

        for (int i = 0; i < _platforms.Length; i++)
        {
            if (_bobbingTimers[i] > 0)
                _bobbingTimers[i] -= time;
            else
            {
                _moveDirections[i] *= -1;
                _bobbingTimers[i] = Random.Range(_bobbingRangeMin, _bobbingRangeMax);
            }
            
            _platforms[i].position += _moveDirections[i] * _bobbingSpeed * time * Vector3.up;
        }
    }
}
