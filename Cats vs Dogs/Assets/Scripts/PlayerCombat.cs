using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCombat : MonoBehaviour
{
    [SerializeField]
    private GameObject bullet;
    [SerializeField]
    public float shootCooldown = 1.5f;
    private bool canFire = true;

    public float bulletSpeed = 5f;
    public Vector3 bulletSize;

    private bool canUpgrade = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bulletSize = new Vector3(0.85f, 0.85f, 0.85f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) && canFire)
        {
            Shooting();
        }

        //StartCoroutine(TemporaryUpgrading());
    }

    void Shooting()
    {
        Instantiate(bullet, transform.position, transform.rotation);
        canFire = false;
        StartCoroutine(DelayShot());
    }

    IEnumerator DelayShot()
    {
        yield return new WaitForSeconds(shootCooldown);
        canFire = true;
        Debug.Log("coroutine initiated");
    }

    //private IEnumerator TemporaryUpgrading()
    //{
    //    if (canUpgrade)
    //    {
    //        canUpgrade = false;
    //        yield return new WaitForSeconds(10);
    //        shootCooldown = shootCooldown / 1.15f;
    //        bulletSpeed = bulletSpeed * 1.05f;
    //        yield return new WaitForSeconds(1);
    //        canUpgrade = true;
    //    }
    //}

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}
