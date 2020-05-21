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
    float t = 0;

    // Update is called once per frame
    void Update()
    {
        if (t >= timeToSpawn)
        {
            GameObject building = Instantiate(buildings[Random.Range(0, buildings.Length)], new Vector3(spawnPoint.position.x, Random.Range(spawnPoint.position.y - 0.5f, spawnPoint.position.y + 0.5f), Random.Range(0.0f, 10.0f)), spawnPoint.rotation);
            building.AddComponent<MoveBuilding>();
            building.GetComponent<MoveBuilding>().setSpeed(speed);
            t = 0;
            timeToSpawn = Random.Range(minTimeToSpawn, maxTimeToSpawn);
        }

        t += Time.deltaTime / timeToSpawn;
    }

}
