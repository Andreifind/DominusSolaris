using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class textCOST : MonoBehaviour
{
    public GameObject player;
    Text lass;
    // Start is called before the first frame update
    void Start()
    {
        //player=GameObject.Find("ship").transform;
        lass = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if(player.GetComponent<Ship>().tax==10)
            lass.text = "This skill will decrease the amount of heat generated from firing the laser. Current level: 0/2. Current heat reduction: 0%";
        else if(player.GetComponent<Ship>().tax==8)
            lass.text = "This skill will decrease the amount of heat generated from firing the laser. Current level: 1/2. Current heat reduction: 20%";
        if(player.GetComponent<Ship>().tax==5)
            lass.text = "This skill will decrease the amount of heat generated from firing the laser. Current level: 2/2. Current heat reduction: 50%";
    }
}
