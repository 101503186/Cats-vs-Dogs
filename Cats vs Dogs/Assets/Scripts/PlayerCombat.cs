using System.Collections;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    [SerializeField]
    private GameObject bullet;
    [SerializeField]
    private float shootCooldown = 1.5f;
    private bool canFire = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) && canFire)
        {
            Shooting();
        }
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
}
