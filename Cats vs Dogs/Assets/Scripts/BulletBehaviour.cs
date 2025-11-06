using System.Collections;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    public float localBulletSpeed = 5f;
    PlayerCombat playerCombat;
    
    private void Awake()
    {
        playerCombat = FindFirstObjectByType<PlayerCombat>();
        localBulletSpeed = playerCombat.bulletSpeed;
        transform.localScale = playerCombat.bulletSize;
    }

    void Update()
    {
        transform.position += transform.right * Time.deltaTime * localBulletSpeed;
        transform.localScale = playerCombat.bulletSize;
        Destroy(gameObject, 18 / localBulletSpeed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
