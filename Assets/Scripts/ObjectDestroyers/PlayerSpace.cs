using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class PlayerSpace : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            player.gameObject.SetActive(false);
        }
    }
}