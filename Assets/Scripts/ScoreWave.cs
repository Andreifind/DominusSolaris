using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreWave : MonoBehaviour
{
    public Transform spawner;
    Text lass;
    // Start is called before the first frame update
    void Start()
    {
        //spawner=GameObject.Find("Spawner").transform;
        
        lass = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        lass.text = "Wave: " + spawner.GetComponent<Spawner>().wave;
    }
}
