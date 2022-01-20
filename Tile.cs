using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Tile은 각 간격 계산기 입니다.
public class Tile
{   //Hex 방식 Tile 사용으로 타일의 크기와 위치계산.
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
    //삼각함수 루트3/2 구현(
    static readonly float WITH_MULTIPLIER = Mathf.Sqrt(3) / 2;
    //return world-spcae position of this tile
    public Vector3 Position()
    {
        //육각형을 원으로 했을때 꼭지점까지의 거리는 Radius(반지름)거리로 Y축 방향으로 전진한 타일의 중심과의 거리는 r*2 = (꼭지점간의)height
        //육각형의 선으로 인접한 방향으로 전진한 타일의 중심점까지의 거리는 삼각함수를 이용해 반지름의 cos30 값의 2배  
        float radius= 1f;
        float height= radius * 2;
        float width = WITH_MULTIPLIER * height;

        //Y축 방향으로 진행시에 면이 인접하도록 하기 위해 0.75f
        float verti = height * 0.75f;
        float horiz = width;

        // Map 에서  X 와 Y는 1칸개념이므로 1칸당 각 중심거리만큼 이동한 위치를 중앙으로 위치
        //X 방향도 마찬가지로 면에 인접하도록 (2행단위 진행시)
        return new Vector3(
            horiz*(this.Q+this.R/2f),
            0,
            verti*this.R
        );
    }
}
