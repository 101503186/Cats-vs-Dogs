using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCombat : MonoBehaviour
{
    [SerializeField] private GameObject bullet;

    [SerializeField] private float shootCooldown = 1.5f;
    [SerializeField] private float bulletSpeed = 5f;
    [SerializeField] private Vector3 bulletSize = new Vector3(0.85f, 0.5f, 0.85f);

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
        GameObject newBullet = Instantiate(bullet, transform.position, transform.rotation);

        // Apply modified stats to the bullet
        newBullet.transform.localScale = bulletSize;

        Rigidbody2D rb = newBullet.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.linearVelocity = transform.right * bulletSpeed;
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
