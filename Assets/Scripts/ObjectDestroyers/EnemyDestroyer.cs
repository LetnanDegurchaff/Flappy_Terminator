using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class EnemyDestroyer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Enemy>(out Enemy enemy))
            enemy.gameObject.SetActive(false);
    }
}