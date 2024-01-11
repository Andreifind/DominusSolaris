using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class DisplayAccuracy : MonoBehaviour
{
    Text lass;
    float hit;
    float fired;
    // Start is called before the first frame update
    void Start()
    {
        PlayerData data = SaveLoad.LoadPlayer();
        hit=data.hitted;
        fired=data.shotsfired;
        lass = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        lass.text = "Accuracy: " + Math.Round(hit/fired*100) + "%";
    }
}
