using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CharacterUnit : MonoBehaviour
{
    TileProperties TP;
    int UnitTileX;
    int UnitTileY;

    public int step;
    public int dice;
    public GameObject CurrentTile;

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
                //roll Dice
                step = Random.Range(1, 7);
                dice = step;
                StartCoroutine(OneStep());
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
        TP = CurrentTile.GetComponent<TileProperties>();
    }
    IEnumerator OneStep()
    {
        while (step > 0)
        {
            yield return new WaitUntil(() => transform.position == CurrentTile.transform.position);
           
            if (TP.afterX != null)
            {
                UnitTileX++;
            }
            else if (TP.afterY != null)
            {
                UnitTileY++;
            }
            else if (TP.beforeX != null)
            {
                UnitTileX--;
            }
            else if (TP.beforeY != null)
            {
                UnitTileY--;
            }
            resetStatus();
            step--;
        }
        isMoving = false;
    }
}

// �� �� �մ� Ÿ���� ������ 1�� �̻��϶� ������ �ַο� ���� �����̱� �����ϸ� �ַο츦 ����� �Լ� �����
// Ÿ�� Ÿ���� ������ ���� �ִ� Ÿ�ϸ� �����ϱ�