using UnityEngine;

public class Decos : MonoBehaviour
{
    public GameObject[] Decorations;

    void Start()
    {
        if (Decorations.Length > 0)
        {
        GenerateDeco();
        }
    }
    void GenerateDeco()
    {
        TileProperties Tile = GetComponentInParent<TileProperties>();
        if(Tile.checker != 0)
        {
            GameObject decos = (GameObject)Instantiate(Decorations[Random.Range(0, Decorations.Length)], transform.position, Quaternion.identity);
            decos.transform.SetParent(transform);
        }

    }
}
