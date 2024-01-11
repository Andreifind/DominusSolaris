using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class textPIERCE : MonoBehaviour
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
        lass.text = "This skill will make your lasers pass through enemy projectiles unscathed. Current level: "+ (player.GetComponent<Ship>().pierce) + "/1.";
    }
}
