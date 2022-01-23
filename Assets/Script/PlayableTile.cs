using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayableTile : MonoBehaviour
{
    public int tileX;
    public int tileY;
    public int checker;
    public TileMap map;

    public GameObject beforeX;
    public GameObject beforeY;
    public GameObject afterX;
    public GameObject afterY;

    private void Start()
    {
        GetNeighbours();
    }
    public void GenerateProperties()
    {
        
    }
    // 플레이어블 타일 주변 인접타일 리스트화 = 진행 가능한 타일
    void GetNeighbours()
    {
        GameObject Neighbour(int x, int y)
        {
                return GameObject.Find("Tile(" + x + "," + y + ")");
        }

        if (tileX > 0 && Neighbour(tileX - 1, tileY).GetComponent<PlayableTile>().checker == 0)
        {
            beforeX = Neighbour(tileX - 1, tileY);
        }
        if (tileX < map.mapSizeX - 1 && Neighbour(tileX + 1, tileY).GetComponent<PlayableTile>().checker == 0)
        {
            afterX = Neighbour(tileX + 1, tileY);
        }
        if (tileY > 0 && Neighbour(tileX, tileY - 1).GetComponent<PlayableTile>().checker == 0)
        {
            beforeY = Neighbour(tileX, tileY - 1);
        }
        if (tileY < map.mapSizeY - 1 && Neighbour(tileX, tileY + 1).GetComponent<PlayableTile>().checker == 0)
        {
            afterY = Neighbour(tileX, tileY + 1);
        }
    }
}
