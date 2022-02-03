using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class World : MonoBehaviour
{
    public GameObject Character;
    public Text diceText;
    // Start is called before the first frame update
    void Start()
    {
        spawnCharac();
    }
    void spawnCharac()
    {
        GameObject player = (GameObject)Instantiate(Character, transform.position, Quaternion.identity);
        player.name = "Player";
;    }
}
