using System.Collections;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    public float localBulletSpeed = 5f;

    void Start()
    {
        localBulletSpeed = PlayerCombat.bulletSpeed;
    }

    void Update()
    {
        transform.position += transform.right * Time.deltaTime * localBulletSpeed;
        Destroy(gameObject, 18 / localBulletSpeed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
