using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject carPrefab;
    public GameObject blockPrefab;
    public int worldWidth = 10;
    public int worldHeight = 1;

    void Start()
    {
        GenerateWorld();
        SpawnCar();
    }

    void GenerateWorld()
    {
        for (int x = 0; x < worldWidth; x++)
        {
            for (int z = 0; z < worldWidth; z++)
            {
                Vector3 position = new Vector3(x, 0, z);
                Instantiate(blockPrefab, position, Quaternion.identity);
            }
        }
    }

    void SpawnCar()
    {
        Vector3 carPosition = new Vector3(worldWidth / 2, 1.5f, worldWidth / 2);
        Instantiate(carPrefab, carPosition, Quaternion.identity);
    }
}