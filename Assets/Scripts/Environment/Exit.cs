using UnityEngine;

public enum ExitType { Upgrade, Money, Marks, Boss, Shop }

public class Exit : MonoBehaviour
{
    [SerializeField] private IntEventChannel _exitEvent;
    [SerializeField] private GameObject _visuals;
    [SerializeField] private GameObject _activateEffect;
    [SerializeField] private GameObject _exitEffect;

    [SerializeField] private ExitUI _exitCanvas;
    [SerializeField] private float _exitWaitTime;

    private ExitType _type;
    private int _playerCount = 0;
    private bool _isChosen = false, _isExiting = false;
    private float _exitTimer;
    private GameObject effect;

    #region ACTIVATION

    void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Player") return;
        
        _isChosen = true;

        if (_playerCount == 0)
            effect = Instantiate(
                _activateEffect,
                transform.position + Vector3.up * 0.1f,
                transform.rotation
            );

        _playerCount++;
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag != "Player") return;

        _playerCount--;

        if (_playerCount == 0)
        {
            _isChosen = false;
            _isExiting = false;
            Destroy(effect);
            _exitCanvas.UpdateTime(-1);
        }
    }

    #endregion

    void Update()
    {
        // exit this chamber
        if (_exitTimer >= _exitWaitTime)
        {
            _exitEvent.RaiseIntEvent((int)_type);
            this.enabled = false;
            GetComponent<CapsuleCollider>().enabled = false;
            return;
        }

        // any player is standing on this teleporter
        if (_isChosen)
        {
            _exitTimer += Time.deltaTime;
            _exitCanvas.UpdateTime(_exitWaitTime - _exitTimer);
        }
        // all players have left this teleporter
        else _exitTimer = 0;

        // create teleport effect
        if (!_isExiting && _exitTimer >= 0.6f * _exitWaitTime)
        {
            Debug.Log("Exiting");
            _isExiting = true;
            Destroy(effect);
            effect = Instantiate(
                _exitEffect,
                transform.position + Vector3.up * 0.1f,
                transform.rotation
            );
        }


    }
}
