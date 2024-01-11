using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scorelaser : MonoBehaviour
{
    private Transform player;
    Text lass;
    // Start is called before the first frame update
    void Start()
    {
        player=GameObject.Find("ship").transform;
        
        lass = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        lass.text = "Lasers: " + player.GetComponent<Ship>().lasers;
    }
}
