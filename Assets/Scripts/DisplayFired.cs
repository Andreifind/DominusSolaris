using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class DisplayFired : MonoBehaviour
{
    Text lass;
    int fired;
    // Start is called before the first frame update
    void Start()
    {
        PlayerData data = SaveLoad.LoadPlayer();
        fired=data.shotsfired;
        lass = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        lass.text = "Lasers fired: " + String.Format("{0:n0}", fired);
    }
}
