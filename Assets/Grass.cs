using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grass : Terrain
{
    [SerializeField] List<GameObject> pohonPrefabList;
    [SerializeField, Range(0, 1)] float pohonProbability;

   
    public void SetPohonPercentage(float newProbability)
    {
        this.pohonProbability = Mathf.Clamp01(newProbability); 
    }
    public override void Generate(int size)
    {
        base.Generate(size);

        var limit = Mathf.FloorToInt((float)size / 2);
        var pohonCount = Mathf.FloorToInt((float)size * pohonProbability );
        
        // membuat daftar posisi yang masih kosong
        List<int> emptyPosition = new List<int>();
        for(int i = -limit; i <= limit; i++)
        {
            emptyPosition.Add(i);
        } 
        for(int i = 0; i < pohonCount; i++)
        {
            //memilih posisi kosong secara random
            var randomIndex = Random.Range(0, emptyPosition.Count);
            var pos = emptyPosition[randomIndex];
            
            //posisi yang terpilih hapus dari daftar posisi kosong
            emptyPosition.RemoveAt(randomIndex);
            SpawnRandomPohon(pos);



        }
        //selalu Pohon diujung
        
        SpawnRandomPohon(-limit + 4);
        SpawnRandomPohon(limit - 4);





    }
    private void SpawnRandomPohon(int pos)
    {
        if (pohonPrefabList.Count == 0)
        {
            Debug.LogError("pohonPrefabList is empty!");
            return;
        }

        // set pohon ke posisi yang terpilih
        var randomIndex = Random.Range(0, pohonPrefabList.Count);
        Debug.Log("Random index: " + randomIndex);
        var prefab = pohonPrefabList[randomIndex];


        //pilih prefab pohon secara random
        var pohon = Instantiate
            (prefab,
             new Vector3(pos, 0, this.transform.position.z),
             Quaternion.identity,
             transform);






    }


}
