using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class DisplayDeaths : MonoBehaviour
{
    Text lass;
    int deaths;
    // Start is called before the first frame update
    void Start()
    {
        PlayerData data = SaveLoad.LoadPlayer();
        deaths=data.deaths;
        lass = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        lass.text = "Deaths: " + String.Format("{0:n0}", deaths);
    }
}
