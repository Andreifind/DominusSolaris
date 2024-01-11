using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Enemy : MonoBehaviour
{
	public int hp;
    public int maxhp;
    public int speed;
    public float atacc;
	public Transform player;
    public Transform spawner;
    public int clasa;
    public bool candie=false;
        // Start is called before the first frame update
    public void Start()
    {
        hp=maxhp;
        player=GameObject.Find("ship").transform;
        spawner=GameObject.FindWithTag("spawner").transform;
    }

    // Update is called once per frame
    public void Update()
    {
			
    }
    public void perish()
    {
            spawner.GetComponent<Spawner>().bossded=1;
            //Debug.Log("bossded");
            Destroy(gameObject);
    }
    public void isded()
    {
        if(hp<=0 && clasa<2 && Time.timeScale==1)
        {
            if(player.GetComponent<Ship>().overheat+player.GetComponent<Ship>().tax*2<100)
                player.GetComponent<Ship>().overheat += player.GetComponent<Ship>().tax*2;
            else player.GetComponent<Ship>().overheat=100;
            if(maxhp>25)
            {
                player.GetComponent<Ship>().exp+=25;
            }
            else player.GetComponent<Ship>().exp+=maxhp;
            if(clasa<2)
                if(player.GetComponent<Ship>().taxred==0.6f) player.GetComponent<Ship>().score+=(maxhp*32+player.GetComponent<Ship>().planet*4)/(player.GetComponent<Ship>().deaths+1);
                else if(player.GetComponent<Ship>().taxred==0.9f) player.GetComponent<Ship>().score+=(maxhp*69+player.GetComponent<Ship>().planet*8)/(player.GetComponent<Ship>().deaths+1);
                    else player.GetComponent<Ship>().score+=2*(maxhp*69+player.GetComponent<Ship>().planet*8)/(player.GetComponent<Ship>().deaths+1);
            else player.GetComponent<Ship>().score+=maxhp*32/(player.GetComponent<Ship>().deaths+1);
        }
        
        if ((hp<=0 || transform.position.x<-15) && clasa==1)
        {
            perish();
        }
        if (player.GetComponent<Ship>().hp<5 || player.GetComponent<Ship>().justloaded || player.GetComponent<Ship>().scenetrigger)
        {
            spawner.GetComponent<Spawner>().nr=0;    
            Destroy(gameObject);
        }
        //if (clasa==1)
    }
    public void zerst()
    {
        Destroy(gameObject);
    }
    public void award()
    {
        player.GetComponent<Ship>().exp+=maxhp;
        player.GetComponent<Ship>().marebos=true;
        //player.GetComponent<Ship>().score+=80000/(player.GetComponent<Ship>().deaths+1);
    }
    public void nrdouazeci()
    {
        spawner.GetComponent<Spawner>().nr=0;
        spawner.GetComponent<Spawner>().planet++;
        Debug.Log("nrdouazeci");
    }
}
