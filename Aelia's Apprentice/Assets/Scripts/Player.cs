using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private GameObject spellPrefab;

    void Start()
    {
        if (spellPrefab == null)
            Debug.LogError(gameObject + " needs to have a spell prefab");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector2 spawnPos = transform.position;
            //Vector2 direction = Vector2.up;
            //float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            //Quaternion rotation = Quaternion.Euler(0, 0, angle);
            Quaternion rotation = Quaternion.identity;

            GameObject projectileObj = Instantiate(spellPrefab, spawnPos, rotation);
            //projectileObj.GetComponent<Projectile>().Direction = direction;
        }
    }
}
