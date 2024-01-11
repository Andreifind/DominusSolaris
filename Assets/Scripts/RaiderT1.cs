using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaiderT1 : Enemy
{
	private Rigidbody2D body= null;
	public GameObject boom;
	public GameObject box;
	public GameObject proj;
	private Vector2 targetPos;
	private float tfire;
	private Vector2 startPos;
	private float oscilate;
	Animator animator;
	private int bocs;
    int attack;
    int ischarge=1;
    float accel=1;
    // Start is called before the first frame update
    void Start()
    {
		animator=GetComponent<Animator>();
       // maxhp=2;
		base.Start();
		tfire= atacc/2;
        //body.velocity = new UnityEngine.Vector2(-1,0);
    }

    // Update is called once per frame
    void Update()
    {
        base.isded();
		if (player.GetComponent<Ship>().planet!=5) Destroy(gameObject);
		if (Time.timeScale>0 && player.GetComponent<Ship>().dialog==false)
		{
		if (tfire <= 0 && transform.position.x<11 && ischarge==1)
                {
                    attack=Random.Range(0, 3);
					tfire = atacc;
                    if(attack==2)
                    {
                        ischarge=0;
                        animator.SetTrigger("charge");
                    }
                    else
						animator.SetTrigger("atac");     
                }
                else if(ischarge!=0)
                    tfire -= Time.deltaTime;
        if(ischarge==1)
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        else
        {
            transform.Translate(Vector2.left * speed * accel * Time.deltaTime);
            if(speed*accel<17) accel+=0.02f;
        } 
		
		//SLIDE
		if (oscilate==0 || transform.position.y+oscilate > 3.3f || transform.position.y+oscilate<-6)
			oscilate=Random.Range(-3, 3);
		else
			if (transform.position.x<8 && ischarge==1)
			do
			{
				targetPos= new Vector2(transform.position.x, transform.position.y+(oscilate/Mathf.Abs(oscilate))* Time.deltaTime*2);
				transform.position=targetPos;
			}while(transform.position.y==oscilate);
		// destroy
		if (hp<=0)
		{
                player.GetComponent<Ship>().overheat += 2*maxhp;
			Instantiate(boom, transform.position, Quaternion.identity);
			//bocs=Random.Range(0, 20);
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
			//hp-=5;
			other.GetComponent<Ship>().hp -= 1;
		}
	}
	}
	public void atac()
	{
        startPos= new Vector2(transform.position.x-0.559f, transform.position.y+0.636f);
		Instantiate(proj, startPos, Quaternion.identity);
		//Instantiate(sprk, startPos, Quaternion.identity);
        tfire = atacc;
		animator.ResetTrigger("atac");
	}
}
