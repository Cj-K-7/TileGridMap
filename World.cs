using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World : MonoBehaviour
{
    public GameObject Character;
    // Start is called before the first frame update
    void Start()
    {
        spawnCharac();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void spawnCharac()
    {
        GameObject player = (GameObject)Instantiate(Character, transform.position, Quaternion.identity);
        player.name = "Player";
;    }
}
