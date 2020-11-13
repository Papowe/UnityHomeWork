using UnityEngine;

public class MineSpawner : MonoBehaviour
{
    [SerializeField] private GameObject mine;
    [SerializeField] private Transform mineSpawner;

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Instantiate(mine, mineSpawner.position, Quaternion.identity);
        }
    }


}
