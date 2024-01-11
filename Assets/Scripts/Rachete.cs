using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rachete : Enemy
{
    // Start is called before the first frame update
    //public int speed;
    //private Transform player;
    public GameObject boom;
    float accel=1;
    //private Vector2 poz;
    void Start()
    {
        //poz= new Vector2(12,transform.position.y);
        //Instantiate(exclam,poz,Quaternion.identity);
        player=GameObject.Find("ship").transform;
        if(player.GetComponent<Ship>().planet==0) maxhp=7;
        if(player.GetComponent<Ship>().planet==1) maxhp=9;
        if(player.GetComponent<Ship>().planet==2) maxhp=12;
        if(player.GetComponent<Ship>().planet==3) maxhp=15;
        if(player.GetComponent<Ship>().planet==5) maxhp=17;
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        base.isded();
        if (hp<=0)
		{
            player.GetComponent<Ship>().overheat += 2*maxhp-player.GetComponent<Ship>().wave;
			Instantiate(boom, transform.position, Quaternion.identity);
			Destroy(gameObject);
		}
        transform.Translate(Vector2.left * speed * Time.deltaTime * accel);
        if (speed*accel<13) accel+=0.03f;
        if(transform.position.x<-48) Destroy(gameObject);
        //if(transform.position.x<=16 &&transform.position.x>=15) player.GetComponent<Ship>().passby=true;
    }
    void OnTriggerEnter2D(Collider2D other)
		{
			if(other.gameObject.tag==("Player"))
            {
                other.GetComponent<Ship>().hp-=10;
                hp=0;
            }
                
		}
}
