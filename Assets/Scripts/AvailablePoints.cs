using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AvailablePoints : MonoBehaviour
{
    private Transform player;
    Text points;
    // Start is called before the first frame update
    void Start()
    {
        player=GameObject.Find("ship").transform;
        
        points = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        points.text = "Available   points: " + player.GetComponent<Ship>().points;
    }
}
