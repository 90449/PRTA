using UnityEngine;
using UnityEngine.UIElements;

public class spawner : MonoBehaviour
{

    public GameObject myMush;
    public GameObject myMush2;

    void Awake()
    {
        for (int i = 0; i < 1000; i++)
        {
            SpawnMush();
            SpawnMush2();
        }
    }

    public float minDistance = 0.5f;

    public void SpawnMush()
    {
        Terrain terrain = Terrain.activeTerrain;

        Vector3 terrainPos = terrain.transform.position;
        Vector3 terrainSize = terrain.terrainData.size;

        Vector3 spawnPosition;
        bool validPosition = false;

        int attempts = 0;
        int maxAttempts = 20;

        while (!validPosition && attempts < maxAttempts)
        {
            float x = Random.Range(terrainPos.x, terrainPos.x + terrainSize.x);
            float z = Random.Range(terrainPos.z, terrainPos.z + terrainSize.z);
            float y = terrain.SampleHeight(new Vector3(x, 0, z)) + terrainPos.y;

            spawnPosition = new Vector3(x, y, z);

            // Check for nearby mushrooms
            Collider[] nearby = Physics.OverlapSphere(spawnPosition, minDistance);

            validPosition = true;

            foreach (Collider col in nearby)
            {
                if (col.CompareTag("Mush"))
                {
                    validPosition = false;
                    break;
                }
            }

            if (validPosition)
            {
                Instantiate(myMush, spawnPosition, Quaternion.identity);
                return;
            }

            attempts++;
        }
    }

    public void SpawnMush2()
    {
        Terrain terrain = Terrain.activeTerrain;

        Vector3 terrainPos = terrain.transform.position;
        Vector3 terrainSize = terrain.terrainData.size;

        Vector3 spawnPosition;
        bool validPosition = false;

        int attempts = 0;
        int maxAttempts = 20;

        while (!validPosition && attempts < maxAttempts)
        {
            float x = Random.Range(terrainPos.x, terrainPos.x + terrainSize.x);
            float z = Random.Range(terrainPos.z, terrainPos.z + terrainSize.z);
            float y = terrain.SampleHeight(new Vector3(x, 0, z)) + terrainPos.y;

            spawnPosition = new Vector3(x, y, z);

            // Check for nearby mushrooms
            Collider[] nearby = Physics.OverlapSphere(spawnPosition, minDistance);

            validPosition = true;

            foreach (Collider col in nearby)
            {
                if (col.CompareTag("Mush"))
                {
                    validPosition = false;
                    break;
                }
            }

            if (validPosition)
            {
                Instantiate(myMush, spawnPosition, Quaternion.identity);
                return;
            }

            attempts++;
        }
    }

}
