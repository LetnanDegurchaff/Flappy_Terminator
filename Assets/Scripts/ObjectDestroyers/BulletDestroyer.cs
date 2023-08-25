using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class BulletDestroyer : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Bullet>(out Bullet bullet))
            Destroy(bullet.gameObject);
    }
}