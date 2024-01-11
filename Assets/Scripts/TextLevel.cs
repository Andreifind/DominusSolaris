using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextLevel : MonoBehaviour
{
    public Transform player;
    Text level;
    // Start is called before the first frame update
    void Start()
    {
        //player=GameObject.Find("ship").transform;
        
        level = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        level.text = "Level: " + player.GetComponent<Ship>().level;
    }
}
