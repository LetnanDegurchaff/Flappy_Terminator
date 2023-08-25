using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
    [SerializeField] private PlayerBullet _bullet;

    private Transform _shootPoint;
    private Rigidbody2D _rigidbody;

    private int _angleCorrection = 90;

    private void Awake()
    {
        _shootPoint = GetComponentInChildren<ShootPoint>().transform;
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
            Shoot();
    }

    private void Shoot()
    {
        PlayerBullet newBullet = Instantiate
            (_bullet, _shootPoint.position, Quaternion.identity);

        newBullet.InitializeDirection(GetDirectionFromAngle(_rigidbody.rotation));
    }

    private Vector2 GetDirectionFromAngle(float angle)
    {
        Vector2 direction = new Vector2();

        angle += _angleCorrection;
        angle /= Mathf.Rad2Deg;

        direction.x = Mathf.Cos(angle);
        direction.y = Mathf.Sin(angle);

        return direction;
    }
}