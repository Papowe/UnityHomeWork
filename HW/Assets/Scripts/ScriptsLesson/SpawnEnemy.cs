using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField] private GameObject prefabEnemy;
    [SerializeField] private GameObject[] spawnPoints;

    public Transform[] wayPoints;

    private void Awake()
    {
        spawnPoints = GameObject.FindGameObjectsWithTag("SpawnPointEnemy");
    }
    private void Start()
    {
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            wayPoints = spawnPoints[i].GetComponentsInChildren<Transform>();

            var enemy = Instantiate(prefabEnemy, spawnPoints[i].transform.position, spawnPoints[i].transform.rotation, this.transform);
            enemy.GetComponent<WaypointPatrol>().SetWaypoint(wayPoints);
        }
    }
}
