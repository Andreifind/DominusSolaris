using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class DisplayHighscore : MonoBehaviour
{
    Text lass;
    int score;
    // Start is called before the first frame update
    void Start()
    {
        PlayerData data = SaveLoad.LoadPlayer();
        score=data.highscore;
        lass = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        lass.text = "Highscore: " + String.Format("{0:n0}", score);
    }
}
