using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class POWERUP : MonoBehaviour
{
    private Transform player;
    // Start is called before the first frame update
    void Start()
    {
        player=GameObject.Find("ship").transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void recheck()
    {
        if (player.GetComponent<Ship>().hp<5)
            Destroy(gameObject);
    }
}
