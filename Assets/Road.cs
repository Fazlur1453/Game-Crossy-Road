using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road : Terrain
{
    [SerializeField] Tiger tigerPrefab;

    [SerializeField] float minTigerSpawnInterval;
    
    [SerializeField] float maxTigerSpawnInterval;

    float timer;

    Vector3 tigerSpawnPosition;

    Quaternion tigerRotation;

    private void Start()
    {
        if (Random.value > 0.5f)
        {
            tigerSpawnPosition = new Vector3(
                horizontalSize / 2 + 3,
                0,
                this.transform.position.z);

            tigerRotation = Quaternion.Euler(0, -90, 0);
        }



        else
        {
            tigerSpawnPosition = new Vector3(
                -(horizontalSize / 2 + 3),
                0,
                this.transform.position.z);

            tigerRotation = Quaternion.Euler(0, 90, 0);
        }
            

        
    }

    private void Update()
    {
        if(timer <= 0)
        {
            timer = Random.Range(
                minTigerSpawnInterval,
                maxTigerSpawnInterval);

            var tiger = Instantiate(
                tigerPrefab, 
                tigerSpawnPosition, 
                tigerRotation);

            tiger.SetUpDistanceLimit(horizontalSize + 6);
            Debug.Log(tigerSpawnPosition +   "   position   ");
            return;

        }
        timer -= Time.deltaTime;
    }
}
