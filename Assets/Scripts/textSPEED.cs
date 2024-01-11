using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class textSPEED : MonoBehaviour
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
        lass.text = "This skill will increase your projectile speed, enhancing your accuracy. Current level: "+ ((player.GetComponent<Ship>().speed-15)/2) + "/5. Current speed: "+ (player.GetComponent<Ship>().speed);
    }
}
