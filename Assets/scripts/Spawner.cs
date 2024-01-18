using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    //singleton instance of this class
    public static Spawner Instance { get; private set; }

    //references to planes prefab
    public GameObject redPlane;
    public GameObject greenPlane;
    public GameObject rainbowPlane;

    //Turret position
    private Vector3 turretPosition;

    //Create singleton instance before starting the app
    private void Awake()
    {
        //if there is an instance other than me, delete myself
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    public void setTurretPosition(Vector3 p_turretPosition)
    {
        turretPosition = p_turretPosition;
    }

    public void spawnPlane(GameObject plane)
    {
        //create an empty gameobject to work with transform
        GameObject planeSpawnPoint = new GameObject();

        //Random height to add from the turret position
        float extraHeight = Random.Range(0.5f, 1.5f);

        //Random depth to add from the turret position
        float extraDepth = Random.Range(0.5f, 1.5f);

        //Create the spawn position
        Vector3 planeSpawnPosition = new Vector3(0.0f, this.turretPosition.y + extraHeight, this.turretPosition.z + extraDepth);

        //set the position of the spawn
        planeSpawnPoint.transform.position = planeSpawnPosition;

        //instance of the plane at the spawn position
        Instantiate(plane, planeSpawnPoint.transform);

    }

    public void spawnRedPlane()
    {
        spawnPlane(redPlane);
    }

    public void spawnGreenPlane()
    {
        spawnPlane(greenPlane);
    }

    public void spawnRainbowPlane()
    {
        spawnPlane(rainbowPlane);
    }

    public void spawnRedPlaneAfterTime(float time)
    {
        Invoke("spawnRedPlane", time);
    }

    public void spawnGreenPlaneAfterTime(float time)
    {
        Invoke("spawnGreenPlane", time);
    }

    public void spawnRainbowPlaneAfterTime(float time)
    {
        Invoke("spawnRainbowPlane", time);
    }
}
