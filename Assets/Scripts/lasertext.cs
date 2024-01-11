using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class lasertext : MonoBehaviour
{
    private Transform player;
    Text lass;
    // Start is called before the first frame update
    void Start()
    {
        
        lass = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        lass.text = "This perk tree will affect your main weapon and its efficiency.";
    }
}
