using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//TileType 타일타입을 구분, 인스턴스에 넣을 오브젝트를 유니티에서 선택할 수 있도록 public
[System.Serializable]
public class TileType
{
    public string name;
    public GameObject tileVisualPrefab;
}
