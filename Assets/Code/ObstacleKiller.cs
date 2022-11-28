using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleKiller : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private ObstacleSpawner _spawner;
    [SerializeField] private float _killDistanceZ;

    // Update is called once per frame
    void Update()
    {
        List<Transform> obstacles = _spawner.spawnedObstacles;

        for(int i = 0; i < obstacles.Count; i++)
        {
            if (_player.position.z > obstacles[i].position.z + _killDistanceZ)
            {
                Destroy(obstacles[i].gameObject);
            }
        }
    }
}
