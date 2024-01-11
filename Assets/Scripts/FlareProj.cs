using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlareProj : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject tunuri;
    Vector2 aaa;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * 4 * Time.deltaTime);
        if(transform.position.x>=19)
        {
            Instantiate(tunuri, transform.position, Quaternion.identity);
            aaa.x=23;
            aaa.y=transform.position.y+3;
            Instantiate(tunuri, aaa, Quaternion.identity);
            aaa.x=26;
            aaa.y=transform.position.y-3;
            Instantiate(tunuri, aaa, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
