using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [Header("Prefabs por direção")]
    [SerializeField] private GameObject[] upPrefabs;
    [SerializeField] private GameObject[] leftPrefabs;
    [SerializeField] private GameObject[] rightPrefabs;

    [Header("Spawn Settings")]
    [SerializeField] private float spawnRangeX = 20f;
    [SerializeField] private float spawnRangeZ = 10f;
    [SerializeField] private float spawnPosZ = 20f;
    [SerializeField] private float spawnPosX = 20f;
    [SerializeField] private float startDelay = 2f;
    [SerializeField] private float spawnInterval = 1.5f;

    private void Start()
    {
        InvokeRepeating(nameof(SpawnRandomAnimalUp), startDelay, spawnInterval);
        InvokeRepeating(nameof(SpawnRandomAnimalLeft), startDelay, spawnInterval);
        InvokeRepeating(nameof(SpawnRandomAnimalRight), startDelay, spawnInterval);
    }

    private void SpawnRandomAnimalUp()
    {
        SpawnRandom(
            upPrefabs,
            new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ),
            Quaternion.Euler(0, 180, 0)
        );
    }

    private void SpawnRandomAnimalLeft()
    {
        SpawnRandom(
            leftPrefabs,
            new Vector3(-spawnPosX, 0, Random.Range(-spawnRangeZ, spawnRangeZ)),
            Quaternion.Euler(0, 90, 0)
        );
    }

    private void SpawnRandomAnimalRight()
    {
        SpawnRandom(
            rightPrefabs,
            new Vector3(spawnPosX, 0, Random.Range(-spawnRangeZ, spawnRangeZ)),
            Quaternion.Euler(0, -90, 0)
        );
    }

    private void SpawnRandom(GameObject[] prefabs, Vector3 position, Quaternion rotation)
    {
        if (prefabs == null || prefabs.Length == 0)
        {
            Debug.LogWarning("Lista de prefabs vazia.");
            return;
        }

        int index = Random.Range(0, prefabs.Length);
        Instantiate(prefabs[index], position, rotation);
    }
}