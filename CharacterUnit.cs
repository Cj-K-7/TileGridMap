using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterUnit : MonoBehaviour
{
    PlayableTile pt;
    int UnitTileX;
    int UnitTileY;
    int step;

    public GameObject CurrentTile;
    public GameObject Arrow;

    bool start;
    bool isMoving;
    bool isEnd;

    private void Start()
    {
        resetStatus();
        isMoving = false;
    }

    // Update is called once per frame
    private void Update()
    {
        Movement();
    }
    //움직임 함수
    void Movement()
    {
        if (!isMoving)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                isMoving = true;
                if (pt.afterX != null)
                {
                    UnitTileX++;
                }
                else if (pt.afterY != null)
                {
                    UnitTileY++;
                }
                else if (pt.beforeX != null)
                {
                    UnitTileX--;
                }
                else if (pt.beforeY != null)
                {
                    UnitTileY--;
                }
                resetStatus();
                new WaitForSeconds(3);
                isMoving = false;
            }
        }

    }
    void FixedUpdate()
    {
            transform.position = Vector3.MoveTowards(transform.position, new Tile(UnitTileX, UnitTileY).Position(), 2f * Time.deltaTime); 
    }
    //현재 상태 갱신 함수
    void resetStatus()
    {
        CurrentTile = GameObject.Find("Tile(" + UnitTileX + "," + UnitTileY + ")");
        pt = CurrentTile.GetComponent<PlayableTile>();
    }

}

// 갈 수 잇는 타일의 갯수가 1개 이상일때 선택지 애로우 띄우고 움직이기 시작하면 애로우를 지우는 함수 만들기
// 타일 타입을 나눠서 갈수 있는 타일만 지정하기