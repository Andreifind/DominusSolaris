using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asteroid3 : Enemy
{
    // Start is called before the first frame update
    public GameObject expl;
    void Start()
    {
        hp=maxhp;
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Rotate(new Vector3(0, 0, 10 * Time.deltaTime));
        transform.Translate(Vector2.left * Time.deltaTime *speed);
        if(hp<0) 
        {
            Instantiate(expl,transform.position,Quaternion.identity);
            base.award();
            //StartCoroutine(cam.Shake(.15f,.17f));
            Destroy(gameObject);
        }
    }
}
