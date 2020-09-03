using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tileManager : MonoBehaviour
{

    public GameObject[] tiles;
    public GameObject[] obstacles;

    private Transform playerTransform;
    private float spawnPositionZ = 0.0f;
    public float tileLength = 10.0f;
    public float shortTileLength = 3.0f;
    private int tilesNumber = 10;


    private List<GameObject> tileList = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        for (int i = 0; i < tilesNumber; i++)
            spawnTile();
        
    }

    private void spawnTile(int index = -1)
    {
        GameObject go;
        int currentIndex = randomIndex();
        go = Instantiate(tiles[currentIndex]) as GameObject;
        go.transform.SetParent(transform); // tiles spawned under tile manager
        go.transform.position = Vector3.forward * spawnPositionZ;

        //if (currentIndex == 0 || currentIndex == 1)
            spawnPositionZ = spawnPositionZ + tileLength;
        //else
          //  spawnPositionZ = spawnPositionZ + shortTileLength;

        tileList.Add(go);
    }
    
    private void removeTile()
    {
        Destroy(tileList[0]);
        tileList.RemoveAt(0);
        Debug.Log("remove TILE");
    }

    private int randomIndex()
    {
        if (tiles.Length <= 1)
            return 1;

        int randomIndex = Random.Range(0, tiles.Length);

        return randomIndex;
    }

    // Update is called once per frame
    void Update()
    {
        if(playerTransform.position.z > spawnPositionZ - tileLength * 8)
        {
            spawnTile();
            removeTile();
        }
    }
}
