using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class textDMG : MonoBehaviour
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
        lass.text = "This skill will increase your laser damage. Current level: "+ (player.GetComponent<Ship>().damage-1) + "/5. Current damage: "+ (player.GetComponent<Ship>().damage);
    }
}
