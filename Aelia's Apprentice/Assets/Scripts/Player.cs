using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector2 spawnPos = transform.position;
            Vector2 direction = Vector2.up;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.Euler(0, 0, angle);

            GameObject projectileObj = Instantiate(projectilePrefab, spawnPos, rotation);
            projectileObj.GetComponent<Projectile>().Direction = direction;
        }
    }
}
