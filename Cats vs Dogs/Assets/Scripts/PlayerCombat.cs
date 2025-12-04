using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCombat : MonoBehaviour
{
    [SerializeField] private GameObject bullet;

    [SerializeField] private float shootCooldown = 1.5f;
    [SerializeField] private float bulletSpeed = 5f;
    [SerializeField] private Vector3 bulletSize = new Vector3(0.85f, 0.5f, 0.85f);

    [SerializeField] public int ProjectileCount = 1;

    private bool canFire = true;

    public float ShootCooldown
    {
        get { return shootCooldown; }
        set { shootCooldown = Mathf.Max(0.05f, value); }
    }

    public float BulletSpeed
    {
        get { return bulletSpeed; }
        set { bulletSpeed = value; }
    }

    public float BulletSize
    {
        get { return bulletSize.x; }
        set
        {
            bulletSize = new Vector3(value, value, value);
        }
    }

    void Update()
    {
        if (Input.GetMouseButton(0) && canFire)
        {
            Shooting();
        }
    }

    void Shooting()
    {
        float angleStep = 10f;   // how wide the spread is
        float startAngle = -(angleStep * (ProjectileCount - 1)) / 2;

        for (int i = 0; i < ProjectileCount; i++)
        {
            float angle = startAngle + angleStep * i;
            Quaternion rot = transform.rotation * Quaternion.Euler(0, 0, angle);

            GameObject newBullet = Instantiate(bullet, transform.position, rot);

            newBullet.transform.localScale = Vector3.one * BulletSize;

            Rigidbody2D rb = newBullet.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.linearVelocity = rot * Vector2.right * bulletSpeed;
            }
        }

        canFire = false;
        StartCoroutine(DelayShot());
    }

    IEnumerator DelayShot()
    {
        yield return new WaitForSeconds(shootCooldown);
        canFire = true;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}
