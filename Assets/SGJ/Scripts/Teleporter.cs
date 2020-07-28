using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Diagnostics;

public enum Location
{
    Room,
    Hall,
    Office
}

[System.Serializable]
public class SpawnPoint
{
    public Location location;
    public Transform spawnpoint;
}

public class Teleporter : MonoBehaviour
{
    public List<SpawnPoint> spawnPoints;

    public Transform playerTr; // TEST

    private const float transitionTime = 1.05f;

    public static Teleporter Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        
    }

    void Update()
    {
        // TEST

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            MoveToLocation(Location.Hall);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            MoveToLocation(Location.Room);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            MoveToLocation(Location.Office);
        }
    }

    // moves the subject to the location's spawn point
    public void MoveToLocation(Location loc)
    {
        SpawnPoint spawnPoint = Instance?.spawnPoints?.Find(x => x.location.Equals(loc));

        if(spawnPoint != null)
        {
            
        }
    }

}
