using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private List<Enemy> _enemyTypes;
    [SerializeField] private VoidEventChannel _enemyDeathEvent;
    [SerializeField] private GameObject _spawnEffect;

    private int _enemiesDead = 0;

    #region SETUP

    void OnEnable()
    {
        _enemyDeathEvent.OnVoidEventRaised += EnemyDeath;
    }

    void OnDisable()
    {
        _enemyDeathEvent.OnVoidEventRaised -= EnemyDeath;
    }

    void Start()
    {
        
    }

    #endregion

    void EnemyDeath()
    {
        _enemiesDead++;
    }
}
