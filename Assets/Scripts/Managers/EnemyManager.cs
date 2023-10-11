using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private List<Enemy> _enemyTypes;
    [SerializeField] private VoidEventChannel _enemyDeathEvent;
    [SerializeField] private GameObject _spawnEffect;
    [SerializeField] private float _startSpawnTime;
    private Vector3 _ignoreY = new(1, 0, 1);
    private float _arenaWidth = 13.5f;
    private int _maxEnemiesParallel = 5;
    private int _enemiesToSpawn, _currentEnemies, _enemiesDead;

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
        _enemiesToSpawn = Random.Range(3, 9);
    }

    void Update()
    {
        // all enemies for this room have been spawned
        if (_enemiesToSpawn <= 0) return;

        // delay between individual spawns
        if (_startSpawnTime > 0)
        {
            _startSpawnTime -= Time.deltaTime;
            return;
        }

        // enough enemies in the room
        if (_currentEnemies == _maxEnemiesParallel) return;

        // spawn new enemy
        StartCoroutine(SpawnEnemy());
        _startSpawnTime = 0.5f;
        _enemiesToSpawn--;
        _currentEnemies++;
    }

    IEnumerator SpawnEnemy()
    {
        var position = Vector3.Scale(Random.insideUnitSphere, _ignoreY) * _arenaWidth;
        var index = Random.Range(0, _enemyTypes.Count);

        var effect = Instantiate(_spawnEffect, position, Quaternion.identity);

        yield return new WaitForSeconds(1.5f);

        Instantiate(_enemyTypes[index], position, Quaternion.identity);

        yield return new WaitForSeconds(0.5f);

        Destroy(effect);
    }

    #endregion

    void EnemyDeath()
    {
        _enemiesDead++;
        _currentEnemies--;
    }
}
