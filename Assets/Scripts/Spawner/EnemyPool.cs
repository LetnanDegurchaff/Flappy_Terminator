using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{
    [SerializeField] private Enemy _prefab;
    [SerializeField] private int _capacity;

    private List<Enemy> _enemies = new List<Enemy>();

    protected void Initialize()
    {
        if (_enemies != null)
            foreach (Enemy enemy in _enemies)
                Destroy(enemy.gameObject);

        for (int i = 0; i < _capacity; i++)
        {
            Enemy newEnemy = Instantiate(_prefab);
            _enemies.Add(newEnemy);
            newEnemy.gameObject.SetActive(false);
        }
    }

    protected void Clear()
    {
        foreach (Enemy enemy in _enemies)
            Destroy(enemy.gameObject);
    }

    protected bool TryGetEnemy(out Enemy newEnemy)
    {
        newEnemy = _enemies.FirstOrDefault(enemy => enemy.gameObject.activeSelf == false);

        return newEnemy != null;
    }
}