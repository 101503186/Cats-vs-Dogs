using UnityEngine;

public class GainExperience : MonoBehaviour
{
    private Experience experienceManager;
    [SerializeField] int experienceAmount;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        experienceManager = FindFirstObjectByType<Experience>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            experienceManager.AddExperience(experienceAmount);
            Debug.Log(experienceAmount + " experience gained");
            Destroy(gameObject);
        }
    }
}
