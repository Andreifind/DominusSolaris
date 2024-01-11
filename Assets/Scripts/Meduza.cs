using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meduza : Enemy
{
	private Rigidbody2D body= null;
	public GameObject boom;
	public GameObject box;
	private Vector2 targetPos;
	private float tfire;
	private Vector2 startPos;
	private float oscilate;
	Animator animator;
	private int bocs;
    bool istop=false;
    bool started=true;
	public int planet;
    // Start is called before the first frame update
    void Start()
    {
		animator=GetComponent<Animator>();
       // maxhp=2;
		base.Start();
        //body.velocity = new UnityEngine.Vector2(-1,0);
        if(transform.position.y>0) istop=true;
    }

    // Update is called once per frame
    void Update()
    {
        base.isded();
		if (player.GetComponent<Ship>().planet!=planet) Destroy(gameObject);
        transform.Translate(Vector2.left * speed * Time.deltaTime);
		
		//SLIDE
        
		//if (oscilate==0 || transform.position.y+oscilate > 3.3f || transform.position.y+oscilate<-6 && started==false)
			//oscilate=Random.Range(-3, 3);
        if(started && istop)
        {
            oscilate=-3;
            started=false;
        }
        if(started && istop==false)
        {
            oscilate=3;
            started=false;
        }
		else
			if (transform.position.x<10)
			do
			{
                if(transform.position.y<-3.3f) oscilate=3;
                if(transform.position.y>3.3f) oscilate=-3;
				targetPos= new Vector2(transform.position.x, transform.position.y+(oscilate/Mathf.Abs(oscilate))* Time.deltaTime*3);
				transform.position=targetPos;
			}while(transform.position.y==oscilate);


		// destroy
		if (hp<=0)
		{
                player.GetComponent<Ship>().overheat += 2*maxhp;
			Instantiate(boom, transform.position, Quaternion.identity);
                //player.GetComponent<Ship>().exp-=maxhp;
			
			//bocs=Random.Range(0, 25);
			//if(bocs==5)
			if((player.GetComponent<Ship>().killscore+1)%69==0)
				Instantiate(box, transform.position, Quaternion.identity);
			Destroy(gameObject);
		}
		if(transform.position.x<-16 )
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
