using UnityEngine;

public class WorldGenerator : MonoBehaviour
{
    public GameObject blockPrefab;
    public int width = 10;
    public int height = 10;

    void Start()
    {
        GenerateWorld();
    }

    void GenerateWorld()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                Vector3 position = new Vector3(x, y, 0);
                Instantiate(blockPrefab, position, Quaternion.identity);
            }
        }
    }
}