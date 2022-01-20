using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterUnit : MonoBehaviour
{
    int UnitTileX;
    int UnitTileY;

    public GameObject CurrentTile;
    public List<GameObject> NextTiles;

    PlayableTile pt;
    bool isMoving;

    private void Start()
    {
        resetStatus();
    }

    // Update is called once per frame
    private void Update()
    {
        Movement();
    }
    //움직임 함수
    void Movement()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            UnitTileX++;
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            UnitTileY++;
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow) && UnitTileX > 0)
        {
            UnitTileX--;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow) && UnitTileY > 0)
        {
            UnitTileY--;
        }
        transform.position = Vector3.MoveTowards(transform.position, new Tile(UnitTileX, UnitTileY).Position(), 2f * Time.deltaTime);
        resetStatus();
    }
    //현재 상태 갱신 함수
    void resetStatus()
    {
        CurrentTile = GameObject.Find("T" + UnitTileX + "_" + UnitTileY);
        NextTiles = CurrentTile.GetComponent<PlayableTile>().neighboursList;
    }
}
