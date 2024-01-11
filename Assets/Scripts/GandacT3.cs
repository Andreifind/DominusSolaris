﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GandacT3 : Enemy
{
	private Rigidbody2D body= null;
	public GameObject boom;
	public GameObject box;
	public GameObject proj;
	private Vector2 targetPos;
	private float tfire;
	private Vector2 startPos;
	private float oscilate;
	private int bocs;
	private Transform spawn;

    // Start is called before the first frame update
    void Start()
    {
        maxhp=6;
		base.Start();
		tfire= atacc/2;
		spawn=GameObject.FindWithTag("spawner").transform;
        //body.velocity = new UnityEngine.Vector2(-1,0);
        
    }

    // Update is called once per frame
    void Update()
    {
        base.isded();
		if (Time.timeScale>0)
		{

			startPos= new Vector2(transform.position.x-0.91f, transform.position.y-0.08f);
		if (tfire <= 0 && transform.position.x<11)
                {
                    Instantiate(proj, startPos, Quaternion.identity);
                    tfire = atacc;
                }
                else
                    tfire -= Time.deltaTime;
        transform.Translate(Vector2.left * speed * Time.deltaTime);
		//SLIDE
		if (oscilate==0 || transform.position.y+oscilate > 3.3f || transform.position.y+oscilate<-6)
			oscilate=Random.Range(-3, 3);
		else
			if (transform.position.x<8)
			do
			{
				targetPos= new Vector2(transform.position.x, transform.position.y+(oscilate/Mathf.Abs(oscilate))/64);
				transform.position=targetPos;
			}while(transform.position.y==oscilate);
		// destroy
		if (hp<=0)
		{
                player.GetComponent<Ship>().overheat += 2*maxhp;
			Instantiate(boom, transform.position, Quaternion.identity);
			bocs=Random.Range(0, 10);
			if(bocs==5)
				Instantiate(box, transform.position, Quaternion.identity);
			Destroy(gameObject);
		}
		if(transform.position.x<-16 || spawn.GetComponent<Spawner>().planet==1)
			Destroy(gameObject);
    }
	
	void OnTriggerEnter2D(Collider2D other)
	{
	if (other.gameObject.tag==("Player"))
        {
			//Destroy(gameObject);
			hp-=5;
			other.GetComponent<Ship>().hp -= 10;
		}
	}
	}
}
