using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaspBeam : MonoBehaviour
{
    float tfire;
	float atacc;
    public GameObject inv;
    // Start is called before the first frame update
    void Start()
    {
        atacc=.02f;
        tfire=atacc;
    }

    // Update is called once per frame
    void Update()
    {
        if (tfire <= 0)
                {
                    Instantiate(inv, transform.position, Quaternion.identity);
                    tfire = atacc;
                }
                else
                    tfire -= Time.deltaTime;
    }
}
