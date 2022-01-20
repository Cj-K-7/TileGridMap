using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayableTile : MonoBehaviour
{
    public int tileX;
    public int tileY;
    public TileMap map;
    public List<GameObject> neighboursList = new List<GameObject>();

    private void Start()
    {
        GenerateNeighbour();
    }
    public void GenerateNeighbour()
    {
        // 플레이어블 타일 주변 인접타일 리스트화
        if (tileX > 0)
        {
            neighboursList.Add(GameObject.Find("T" + (tileX - 1) + "_" + tileY));
        }
        if (tileX < map.mapSizeX - 1)
        {
            neighboursList.Add(GameObject.Find("T" + (tileX + 1) + "_" + tileY));
        }
        if (tileY > 0)
        {
            neighboursList.Add(GameObject.Find("T" + tileX + "_" + (tileY - 1)));
        }
        if (tileY < map.mapSizeY - 1)
        {
            neighboursList.Add(GameObject.Find("T" + tileX + "_" + (tileY + 1)));
        }
    }
}
