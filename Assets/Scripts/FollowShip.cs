using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowShip : MonoBehaviour
{
    public float offsetx;
    public float offsety;
    public GameObject player;
    Vector2 newpos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        newpos=new Vector2(player.transform.position.x+offsetx, player.transform.position.y+offsety);
        transform.position=newpos;
    }
}
