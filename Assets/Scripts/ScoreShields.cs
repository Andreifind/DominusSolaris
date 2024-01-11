using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreShields : MonoBehaviour
{
    private Transform player;
    Text lass;
    // Start is called before the first frame update
    void Start()
    {
        player=GameObject.Find("ship").transform;
        
        lass = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        lass.text = "Shields: " + player.GetComponent<Ship>().shields;
    }
}
