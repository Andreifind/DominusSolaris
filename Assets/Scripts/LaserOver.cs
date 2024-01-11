using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserOver : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject textlaser;
    void Start()
    {
        
    }

    // Update is called once per frame
    void OnMouseOver()
    {
        textlaser.SetActive(true);
    }
    void OnMouseExit()
    {
        textlaser.SetActive(false);
    }
}
