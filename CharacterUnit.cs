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
    //������ �Լ�
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
    //���� ���� ���� �Լ�
    void resetStatus()
    {
        CurrentTile = GameObject.Find("Tile(" + UnitTileX + "," + UnitTileY + ")");
        pt = CurrentTile.GetComponent<PlayableTile>();
    }

}

// �� �� �մ� Ÿ���� ������ 1�� �̻��϶� ������ �ַο� ���� �����̱� �����ϸ� �ַο츦 ����� �Լ� �����
// Ÿ�� Ÿ���� ������ ���� �ִ� Ÿ�ϸ� �����ϱ�