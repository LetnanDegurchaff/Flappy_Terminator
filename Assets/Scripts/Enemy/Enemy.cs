using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(EnemyMover))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private EnemyBullet _bullet;
    [SerializeField] private float _shootingDelay;
    [SerializeField] private float _shootingDelayRange;

    private float _currentShootDelay;
    private float _elapsedTime;

    private List<Transform> _shootPoints = new List<Transform>();
    private Vector3 _bulletDirection;

    private void Awake()
    {
        ShootPoint[] shootPoints = GetComponentsInChildren<ShootPoint>();

        foreach (ShootPoint shootPoint in shootPoints)
            _shootPoints.Add(shootPoint.transform);
    }

    private void Start()
    {
        SetNewShootingDelay();
        _elapsedTime = 0;
        _bulletDirection = Vector2.left;
    }

    private void Update()
    {
        _elapsedTime += Time.deltaTime;

        if (_elapsedTime >= _currentShootDelay)
        {
            SetNewShootingDelay();
            _elapsedTime = 0;

            Shoot();
        }
    }

    private void Shoot()
    {
        Vector3 shootPoint = 
            _shootPoints[Random.Range(0, _shootPoints.Count)].transform.position;

        EnemyBullet newBullet =
            Instantiate(_bullet);

        newBullet.transform.position = shootPoint;
        newBullet.InitializeDirection(_bulletDirection);
    }

    private void SetNewShootingDelay()
    {
        _currentShootDelay = _shootingDelay + 
            Random.Range(-_shootingDelayRange, _shootingDelayRange);
    }
}