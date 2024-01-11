using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class ScoreScore : MonoBehaviour
{
    public Transform player;
    Text lass;
    int score;
    public bool endscene;
    // Start is called before the first frame update
    void Start()
    {
        lass = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
            if(player.GetComponent<Ship>().score<1000)
                lass.text = "Score: " + player.GetComponent<Ship>().score;
            else lass.text = "Score: " + String.Format("{0:n0}", player.GetComponent<Ship>().score);  
    }
}
