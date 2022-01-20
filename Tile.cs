using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Tile�� �� ���� ���� �Դϴ�.
public class Tile
{   //Hex ��� Tile ������� Ÿ���� ũ��� ��ġ���.
    public Tile(int q, int r)
    {
        this.Q = q;
        this.R = r;
        this.S = -(q + r);
    }

    // Column + Row + S = 0 => S = - (Column+Row)

    public readonly int Q;
    public readonly int R;
    public readonly int S;
    //�ﰢ�Լ� ��Ʈ3/2 ����(
    static readonly float WITH_MULTIPLIER = Mathf.Sqrt(3) / 2;
    //return world-spcae position of this tile
    public Vector3 Position()
    {
        //�������� ������ ������ ������������ �Ÿ��� Radius(������)�Ÿ��� Y�� �������� ������ Ÿ���� �߽ɰ��� �Ÿ��� r*2 = (����������)height
        //�������� ������ ������ �������� ������ Ÿ���� �߽��������� �Ÿ��� �ﰢ�Լ��� �̿��� �������� cos30 ���� 2��  
        float radius= 1f;
        float height= radius * 2;
        float width = WITH_MULTIPLIER * height;

        //Y�� �������� ����ÿ� ���� �����ϵ��� �ϱ� ���� 0.75f
        float verti = height * 0.75f;
        float horiz = width;

        // Map ����  X �� Y�� 1ĭ�����̹Ƿ� 1ĭ�� �� �߽ɰŸ���ŭ �̵��� ��ġ�� �߾����� ��ġ
        //X ���⵵ ���������� �鿡 �����ϵ��� (2����� �����)
        return new Vector3(
            horiz*(this.Q+this.R/2f),
            0,
            verti*this.R
        );
    }
}
