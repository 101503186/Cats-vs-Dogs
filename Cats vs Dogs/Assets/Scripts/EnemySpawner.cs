using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private float spawnRate = 2f;
    [SerializeField]
    private GameObject[] enemyPrefabs;
    [SerializeField]
    private bool canSpawn = true;

    public Transform target;
    [SerializeField]
    private Vector3 offset;
    private Vector3 vel = Vector3.zero;

    private Experience experience;

    private void Start()
    {
        experience = FindFirstObjectByType<Experience>();
        StartCoroutine(Spawner());
    }

    private void Update()
    {
        Vector3 targetPosition = target.position + offset;

        targetPosition.z = transform.position.z;

        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref vel, 1);
    }

    private IEnumerator Spawner()
    {
        WaitForSeconds wait = new WaitForSeconds(spawnRate);

        while (canSpawn)
        {
            yield return wait;

            int playerLevel = (experience != null) ? experience.CurrentLevel : 1;
            int spawnAmount = 1 + (playerLevel / 5);

            for (int i = 0; i < spawnAmount; i++)
            {
                int rand = Random.Range(0, enemyPrefabs.Length);
                GameObject enemyToSpawn = enemyPrefabs[rand];

                Instantiate(enemyToSpawn, transform.position, Quaternion.identity);
            }
        }
    }
}
