using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : EnemyPool
{
    [SerializeField] private float _spawnDelay;
    private float _elapsedTime;

    private List<Transform> _spawnPoints = new List<Transform>();

    private void Awake()
    {
        SpawnPoint[] spawnPoints = GetComponentsInChildren<SpawnPoint>();

        foreach (SpawnPoint spawnPoint in spawnPoints)
            _spawnPoints.Add(spawnPoint.transform);
    }

    private void OnEnable()
    {
        Initialize();
        _elapsedTime = 0;
    }

    private void OnDisable()
    {
        Clear();
    }

    private void Update()
    {
        _elapsedTime += Time.deltaTime;

        if (_elapsedTime < _spawnDelay)
            return;

        if (TrySpawnEnemy(out Enemy newEnemy))
        {
            _elapsedTime = 0;

            newEnemy.gameObject.SetActive(true);
            newEnemy.transform.position =
                _spawnPoints[Random.Range(0, _spawnPoints.Count)].transform.position;
        }
    }

    private bool TrySpawnEnemy(out Enemy newEnemy)
    {
        bool isSpawned = TryGetEnemy(out newEnemy);

        return isSpawned;
    }
}