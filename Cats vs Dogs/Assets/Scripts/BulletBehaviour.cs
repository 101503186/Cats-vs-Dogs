using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    [SerializeField]
    private float bulletSpeed = 5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.right * Time.deltaTime * bulletSpeed;
        Destroy(gameObject, 18 / bulletSpeed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
