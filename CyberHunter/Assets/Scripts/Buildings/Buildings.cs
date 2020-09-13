using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buildings : MonoBehaviour
{
    [SerializeField] GameObject[] buildings;
    [SerializeField] float speed;
    [SerializeField] float timeToSpawn;
    [SerializeField] float minTimeToSpawn;
    [SerializeField] float maxTimeToSpawn;
    [SerializeField] Transform spawnPoint;
    [SerializeField] float minY;
    [SerializeField] float maxY;
    [SerializeField] float maxZ;
    [SerializeField] float minZ;
    float t = 0;

    // Update is called once per frame
    void Update()
    {
        if (t >= timeToSpawn)
        {
            GameObject building = Instantiate(buildings[Random.Range(0, buildings.Length)], new Vector3(spawnPoint.position.x, Random.Range(spawnPoint.position.y + minY, spawnPoint.position.y + maxY), Random.Range(minZ, maxZ)), spawnPoint.rotation);
            building.AddComponent<MoveBuilding>();
            building.GetComponent<MoveBuilding>().setSpeed(speed);
            t = 0;
            timeToSpawn = Random.Range(minTimeToSpawn, maxTimeToSpawn);
        }

        t += Time.deltaTime / timeToSpawn;
    }

}
