using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class TileMap : MonoBehaviour
{
    public int mapSizeX=10;
    public int mapSizeY=10;

    public CharacterUnit player;
    //Ÿ�� �Ӽ���
    public TileType[] tileTypes;

    public GameObject Arrow;
    //��ǥ ��� Ÿ�� X�� Y�� Ÿ�� ���
    public int[,] tile;

    // Start is called before the first frame update
    void Start()
    {
        GenerateMapData();
    }
    // �� XY ���� + Ÿ�� �Ӽ� ���� �Լ�
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
                TileType tt = tileTypes[ tile[x, y] ];
                // instantiate �ν��Ͻ� ������(for �ݺ��� ��ŭ ���ӿ�����Ʈ Ÿ�� ����)
                GameObject hex_tile = (GameObject)Instantiate(tt.tileVisualPrefab, T.Position(), Quaternion.identity);
                //��Ÿ�� �̸� �ο�
                hex_tile.name = "Tile(" + x + "," + y+")";
                //TileMap ��ü�� ��� Ÿ�ϵ��� �θ��
                hex_tile.transform.SetParent(this.transform);
                //�÷��̾�� Ÿ�� ���� :  Ÿ�� �ο�  / X, Y ��ǥ �ο�
                PlayableTile pt = hex_tile.GetComponent<PlayableTile>();
                pt.tileX = x;
                pt.tileY = y;
                pt.map = this;
            }
        }
    }
}
