using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DiceText : MonoBehaviour
{
    public Text diceText;
    public GameObject player;
    
    // Update is called once per frame
    void Update()
    {
        getInfo();
    }
    void getInfo()
    {
        player = GameObject.Find("Player");
        int diceNumber = player.GetComponent<CharacterUnit>().dice;
        diceText.text = diceNumber.ToString();
    }
}
