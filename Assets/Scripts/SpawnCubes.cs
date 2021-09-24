using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCubes : MonoBehaviour
{
    public int XSize = 10;
    public int YSize = 10;

    private int[,] map;

    public GameObject DarkGrid;
    public GameObject LightGrid;

    private void Start()
    {
        map = new int[XSize, YSize];

        var tmp = 0;

        for (int tmpX = 0; tmpX < XSize; tmpX++)
        {
            for (int tmpY = 0; tmpY < YSize; tmpY++)
            {
                if(tmp == 0)
                {
                    map[tmpX, tmpY] = 0;
                    tmp = 1;
                }
                else if (tmp == 1)
                {
                    map[tmpX, tmpY] = 1;
                    tmp = 0;
                }
            }
        }
        Spawnblocks();
    }

    void Spawnblocks()
    {
        for (int tmpX = 0; tmpX < XSize; tmpX++)
        {
            for (int tmpY = 0; tmpY < YSize; tmpY++)
            {
                if(map[tmpX, tmpY] == 0)
                {
                    Instantiate(DarkGrid, new Vector3(tmpX, 0, tmpY), Quaternion.identity);
                }
                else if (map[tmpX, tmpY] == 1)
                {
                    Instantiate(LightGrid, new Vector3(tmpX, 0, tmpY), Quaternion.identity);
                }
            }
        }
    }
}
