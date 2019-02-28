using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour {
    public TerrainObj waterPrefab;
    public TerrainObj grassPrefab;
    public TerrainObj mountainPrefab;
    public TerrainObj woodPrefab;

    int[,] intMap;

    TerrainObj[,] map;
    public TerrainObj[,] Map
    {
        get
        {
            return map;
        }

        set
        {
            map = value;
        }
    }

    private void Start()
    {
        intMap = new int[,] {
            { 0, 0, 1, 0, 0, 0, 3, 3, 3, 3 } ,
            { 0, 0, 1, 0, 0, 0, 0, 3, 3, 3 } ,
            { 0, 0, 1, 1, 1, 0, 0, 0, 3, 3 } ,
            { 0, 0, 0, 0, 1, 0, 0, 1, 3, 3 } ,
            { 0, 0, 0, 0, 0, 0, 0, 1, 0, 0 } ,
            { 2, 2, 0, 0, 0, 0, 0, 1, 1, 0 } ,
            { 2, 2, 0, 0, 0, 0, 0, 0, 1, 0 } ,
            { 2, 2, 0, 0, 0, 0, 0, 0, 1, 0 } ,
            { 2, 2, 2, 2, 0, 0, 0, 0, 1, 0 } ,
            { 2, 2, 2, 0, 0, 0, 0, 0, 1, 0 }
        };

        int width = intMap.GetLength(0);
        int height = intMap.GetLength(1);

        Camera.main.transform.position = new Vector3(width / 2f - 0.5f, height / 2f - 0.5f, -10f);

        Map = new TerrainObj[width, height];

        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                switch (intMap[i,j])
                {
                    case 0:
                        Map[i, j] = Instantiate(grassPrefab, new Vector3(i, j, 0), Quaternion.identity);
                        Map[i, j].type = TerrainObj.Type.grass;
                        break;
                    case 1:
                        Map[i, j] = Instantiate(waterPrefab, new Vector3(i, j, 0), Quaternion.identity);
                        Map[i, j].type = TerrainObj.Type.water;
                        break;
                    case 2:
                        Map[i, j] = Instantiate(woodPrefab, new Vector3(i, j, 0), Quaternion.identity);
                        Map[i, j].type = TerrainObj.Type.wood;
                        break;
                    case 3:
                        Map[i, j] = Instantiate(mountainPrefab, new Vector3(i, j, 0), Quaternion.identity);
                        Map[i, j].type = TerrainObj.Type.mountain;
                        break;
                    default:
                        Debug.LogError("Map Error");
                        break;
                }
                Map[i, j].transform.SetParent(this.transform);
            }
        }
    }
}
