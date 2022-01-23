using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class TileMap : MonoBehaviour
{
    public int mapSizeX=10;
    public int mapSizeY=10;

    public CharacterUnit player;
    //타일 속성값
    public TileType[] tileTypes;

    public GameObject Arrow;
    //좌표 기반 타일 X열 Y행 타일 대상
    public int[,] tile;

    // Start is called before the first frame update
    void Start()
    {
        GenerateMapData();
    }
    // 맵 XY 생성 + 타일 속성 정의 함수
    void GenerateMapData()
    {

        tile = new int[mapSizeX, mapSizeY];

        for (int x = 0; x < mapSizeX; x++)
        {
            for (int y = 0; y < mapSizeY; y++)
            {
                tile[x, y] = 0;
            }
        }

        for (int x = 0; x < 5; x++)
        {
            for (int y = 1; y < 6; y++)
            {
                tile[x, y] = 1;
            }
        }

        for (int x = 1; x < 4; x++)
        {
            for (int y = 2; y < 5; y++)
            {
                tile[x, y] = 2;
            }
        }

        for (int x = 6; x < 9; x++)
        {
            for (int y = 0; y < 9; y++)
            {
                tile[x, y] = 2;
            }
        }


        GenerateMapVisual();
    }

    // 맵 생성 함수
    void GenerateMapVisual()
    {
        for (int x = 0; x < mapSizeX; x++)
        {
            for (int y = 0; y < mapSizeY; y++)
            {
                //Tile.cs 에서 타일의 위치계산 적용 => Position 값을 사용하기 위해
                Tile T = new Tile(x, y);
                //TileType.cs 에서 각 타일들에 타입 prop 적용 => 인스턴트 콜에서 생성할 타일(타일타입) 적용 
                TileType tt = tileTypes[ tile[x, y] ];
                // instantiate 인스턴스 생성콜(for 반복문 만큼 게임오브젝트 타일 생성)
                GameObject hex_tile = (GameObject)Instantiate(tt.tileVisualPrefab, T.Position(), Quaternion.identity);
                //헥스타일 이름 부여
                hex_tile.name = "Tile(" + x + "," + y+")";
                //TileMap 개체를 모든 타일들의 부모로
                hex_tile.transform.SetParent(this.transform);
                //플레이어블 타일 변수 :  타입 부여  / X, Y 좌표 부여
                PlayableTile pt = hex_tile.GetComponent<PlayableTile>();
                pt.tileX = x;
                pt.tileY = y;
                pt.map = this;
            }
        }
    }
}
