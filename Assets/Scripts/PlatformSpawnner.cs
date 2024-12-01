using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawnner : MonoBehaviour
{
    // Reference to the platform prefab to be spawned
    [SerializeField]
    private GameObject platform;

    // Reference to the diamond prefab to be spawned occasionally on platforms
    [SerializeField]
    private GameObject diamond;

    // Keeps track of the last spawned platform's position
    Vector3 lastPos;

    // Stores the size of the platform (assumed to be the x scale)
    float size;

    // Flag to check if the game is over
    public bool gameOver;

    // Start is called before the first frame update
    void Start()
    {
        // Initialize lastPos with the initial position of the first platform
        lastPos = platform.transform.position;

        // Get the size of the platform (assuming platforms are uniform cubes)
        size = platform.transform.localScale.x;

        // Pre-spawn the first 20 platforms
        for (int i = 0; i < 20; i++)
        {
            SpawnPlatform();
        }
    }

    // Method to start repeatedly spawning platforms
    public void StartPlatformSpawnnig()
    {
        // Start invoking the SpawnPlatform method repeatedly every 0.2 seconds, after a 2-second delay
        InvokeRepeating("SpawnPlatform", 2f, 0.2f);
    }

    // Update is called once per frame
    void Update()
    {
        // Stop spawning platforms if the game is over
        if (GameManager.Instance.gameOver)
        {
            CancelInvoke("SpawnPlatform");
        }
    }

    // Method to spawn a platform in the X direction
    void SpawnX()
    {
        // Calculate the new position in the X direction
        Vector3 pos = lastPos;
        pos.x += size;

        // Update lastPos to the new position
        lastPos = pos;

        // Instantiate a new platform at the new position
        Instantiate(platform, pos, Quaternion.identity);

        // Random chance to spawn a diamond on this platform
        int rand = Random.Range(0, 9);
        if (rand == 0)
        {
            Instantiate(diamond, new Vector3(pos.x, pos.y + 1, pos.z), diamond.transform.rotation);
        }
    }

    // Method to spawn a platform in the Z direction
    void SpawnZ()
    {
        // Calculate the new position in the Z direction
        Vector3 pos = lastPos;
        pos.z += size;

        // Update lastPos to the new position
        lastPos = pos;

        // Instantiate a new platform at the new position
        Instantiate(platform, pos, Quaternion.identity);

        // Random chance to spawn a diamond on this platform
        int rand = Random.Range(0, 9);
        if (rand == 0)
        {
            Instantiate(diamond, new Vector3(pos.x, pos.y + 1, pos.z), diamond.transform.rotation);
        }
    }

    // Method to spawn a platform in either the X or Z direction
    void SpawnPlatform()
    {
        int random = Random.Range(0, 6);

        // 50% chance to spawn a platform in the X direction
        if (random < 3)
        {
            SpawnX();
        }
        // 50% chance to spawn a platform in the Z direction
        else if (random > 3)
        {
            SpawnZ();
        }
    }
}
