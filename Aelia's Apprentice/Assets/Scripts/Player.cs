using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private GameObject spellPrefab1;
    [SerializeField] private GameObject spellPrefab2;

    void Start()
    {
        if (spellPrefab1 == null)
            Debug.LogError(gameObject + " needs to have a spell prefab 1");

        if (spellPrefab2 == null)
            Debug.LogError(gameObject + " needs to have a spell prefab 2");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Vector2 spawnPos = transform.position;
            Vector2 direction = Vector2.up;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.Euler(0, 0, angle);

            GameObject projectileObj = Instantiate(spellPrefab1, spawnPos, rotation);
            projectileObj.GetComponent<Projectile>().Direction = direction;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Vector2 spawnPos = transform.position;
            Quaternion rotation = Quaternion.identity;

            GameObject areaObj = Instantiate(spellPrefab2, spawnPos, rotation);
        }
    }
}
