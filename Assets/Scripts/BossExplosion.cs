using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossExplosion : MonoBehaviour
{
    Transform player;
    // Start is called before the first frame update
    void Start()
    {
        player=GameObject.Find("ship").transform;
        player.GetComponent<Ship>().exp=player.GetComponent<Ship>().targetexp;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
