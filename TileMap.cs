using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class TileMap : MonoBehaviour
{
    public int mapSizeX=10;
    public int mapSizeY=10;

    public GameObject playerUnit;
    //Ÿ�� �Ӽ���
    public TileType[] tileTypes;

    //��ǥ ��� Ÿ�� X�� Y�� Ÿ�� ���
    public int[,] tiles;

    // Start is called before the first frame update
    void Start()
    {
        GenerateMapData();
        
    }

    // �� XY ���� + Ÿ�� �Ӽ� ���� �Լ�
    void GenerateMapData()
    {

        tiles = new int[mapSizeX, mapSizeY];

        for (int x = 0; x < mapSizeX; x++)
        {
            for (int y = 0; y < mapSizeY; y++)
            {
                // x , y ��° Ÿ���� Path = 0 , Obstacle = 1
                tiles[x, y] = 0;
            }
        }
        tiles[2, 2] = 1;
        GenerateMapVisual();
    }

    // �� ���� �Լ�
    void GenerateMapVisual()
    {
        for (int x = 0; x < mapSizeX; x++)
        {
            for (int y = 0; y < mapSizeY; y++)
            {
                //Tile.cs ���� Ÿ���� ��ġ��� ���� => Position ���� ����ϱ� ����
                Tile T = new Tile(x, y);
                //TileType.cs ���� �� Ÿ�ϵ鿡 Ÿ�� prop ���� => �ν���Ʈ �ݿ��� ������ Ÿ��(Ÿ��Ÿ��) ���� 
                TileType tt = tileTypes[ tiles[x, y] ];
                // instantiate �ν��Ͻ� ������(for �ݺ��� ��ŭ ���ӿ�����Ʈ Ÿ�� ����)
                GameObject hex_tile = (GameObject)Instantiate(tt.tileVisualPrefab, T.Position(), Quaternion.identity);
                //��Ÿ�� �̸� �ο�
                hex_tile.name = "T" + x + "_" + y;
                //TileMap ��ü�� ��� Ÿ�ϵ��� �θ��
                hex_tile.transform.SetParent(this.transform);

                //�÷��̾�� Ÿ�� �Ӽ� �ο�, X, Y ��ǥ �ο�
                PlayableTile pt = hex_tile.GetComponent<PlayableTile>();
                pt.tileX = x;
                pt.tileY = y;
                pt.map = this;
            }
        }
    }
}
