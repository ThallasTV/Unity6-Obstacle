using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject spherePrefab; // Prefab of the sphere to spawn
    [SerializeField] private Transform rampTransform; // Reference to the ramp object
    [SerializeField] private Transform rampTransformTwo; // Reference to the ramp object
    [SerializeField] private float spawnInterval = 2f; // Time interval between spawns
    [SerializeField] private float spawnHeight = 5f; // Height above the ramp to spawn spheres
    [SerializeField] private float spawnRangeX = 10f; // Range along the X-axis for spawning

    private float timer;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnSphere();
            timer = 0f;
        }
    }

    void SpawnSphere()
    {
        // Calculate a random X position within the spawn range
        float randomX = Random.Range(-spawnRangeX, spawnRangeX);

        // Determine the spawn position above the ramp
        Vector3 spawnPosition = new Vector3(rampTransform.position.x + randomX, rampTransform.position.y + spawnHeight,
                                            rampTransform.position.z
        );

        Vector3 spawnPositionTwo = new Vector3(rampTransformTwo.position.x + randomX, rampTransformTwo.position.y + spawnHeight,
                                                rampTransformTwo.position.z
        );

        // Instantiate the sphere at the calculated position
        Instantiate(spherePrefab, spawnPosition, Quaternion.identity);
        Instantiate(spherePrefab, spawnPositionTwo, Quaternion.identity);
    }
}
