using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    [SerializeField] private GameObject[] spawnPoints;

    private void Awake()
    {
        spawnPoints = GameObject.FindGameObjectsWithTag("SpawnPointEnemy");
    }
    private void Start()
    {
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            Instantiate(enemy, spawnPoints[i].transform.position, spawnPoints[i].transform.rotation, spawnPoints[i].transform);
        }
    }
}
