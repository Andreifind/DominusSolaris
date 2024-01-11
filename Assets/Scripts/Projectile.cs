using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform playa;
    void Start()
    {
        playa=GameObject.Find("ship").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (playa.GetComponent<Ship>().justloaded || playa.GetComponent<Ship>().scenetrigger) Destroy(gameObject);
    }
}
