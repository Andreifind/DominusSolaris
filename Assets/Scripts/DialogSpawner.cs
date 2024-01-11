using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogSpawner : MonoBehaviour
{
    public GameObject player;
    public GameObject dialogus;
    Vector2 lpos;
    public bool tr=true;
    // Start is called before the first frame update
    void Start()
    {
        lpos= new Vector2(400, 225);
    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<Ship>().dialog==true && tr)
        {
            Instantiate(dialogus,lpos,Quaternion.identity);
            tr=false;
        }
        if (player.GetComponent<Ship>().dialog==false)
            tr=true;
    }

}
