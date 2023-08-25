using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    [SerializeField] private float _maxAngle;
    [SerializeField] private float _minAngle;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _jumpSpeed;

    private Quaternion _upperRotationt;
    private Quaternion _lowerRotationt;

    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();

        _upperRotationt = Quaternion.Euler(0, 0, _maxAngle);
        _lowerRotationt = Quaternion.Euler(0, 0, _minAngle);
    }

    private void Update()
    {
        transform.rotation = Quaternion.Lerp
            (transform.rotation, _lowerRotationt, _rotationSpeed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space))
            Jump();
    }

    private void Jump()
    {
        transform.rotation = _upperRotationt;
        _rigidbody.velocity = Vector2.up * _jumpSpeed;
    }
}