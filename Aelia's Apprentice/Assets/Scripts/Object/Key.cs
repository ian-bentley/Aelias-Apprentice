using UnityEngine;

public class Key : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Will only interact with Players
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            Debug.Log("Key has been collected");
            Player player = collision.gameObject.GetComponent<Player>();
            player.HasKey = true;
            gameObject.SetActive(false);
        }
    }
}
