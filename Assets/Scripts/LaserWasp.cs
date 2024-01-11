using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserWasp : Enemy
{
    private Rigidbody2D body= null;
	public GameObject boom;
	public GameObject box;
	public GameObject LaserBeam;
	private Vector2 targetPos;
	private float tfire;
	private Vector2 startPos;
	private float oscilate;
	Animator animator;
	private int bocs;
	private Transform playe;
    int osc=1;
    int i=0;
    // Start is called before the first frame update
    void Start()
    {
        animator=GetComponent<Animator>();
       // maxhp=2;
		base.Start();
		playe = GameObject.FindWithTag("Player").transform;
		if(playe.GetComponent<Ship>().wave!=3)tfire= 0;
		else tfire=atacc/2;
    }

    // Update is called once per frame
    void Update()
    {
        base.isded();
		if (player.GetComponent<Ship>().planet!=3) Destroy(gameObject);
		if (Time.timeScale>0 && player.GetComponent<Ship>().dialog==false)
		{

			startPos= new Vector2(transform.position.x-0.91f, transform.position.y-0.08f);
		if (tfire <= 0 && transform.position.x<10 && transform.position.y>-1)
                {
                    animator.SetTrigger("atac");
                    osc=0;
		            LaserBeam.SetActive(true);
                    tfire = atacc;
                    //animator.ResetTrigger("atac");
                }
                else if (transform.position.x<10)
                    tfire -= Time.deltaTime;
        if(playe.GetComponent<Ship>().wave==3)
		{
			if (transform.position.x<5) transform.Translate(Vector2.left * speed * Time.deltaTime);
			if (transform.position.x>=5) transform.Translate(Vector2.left * speed * 2 * Time.deltaTime);
		}
		else transform.Translate(Vector2.left * speed * Time.deltaTime);
		
		
		//SLIDE
		if (oscilate==0 || transform.position.y+oscilate > 3.3f || transform.position.y+oscilate<-4)
			oscilate=Random.Range(-3, 3);
		else
			if (transform.position.x<10)
			do
			{
				targetPos= new Vector2(transform.position.x, transform.position.y+osc*(oscilate/Mathf.Abs(oscilate))* Time.deltaTime*1.5f);
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
			hp-=5;
			other.GetComponent<Ship>().hp -= 10;
		}
	}
	}
	public void atac()
	{
        if (i==4)
        {
            animator.ResetTrigger("atac");
            animator.SetTrigger("atacover");
            LaserBeam.SetActive(false);
            i=0;
            osc=1;
        }
		Debug.Log(i);
        i++;
	}
}
