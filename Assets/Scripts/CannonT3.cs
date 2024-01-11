using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonT3 : Enemy
{
	private Rigidbody2D body;
	public GameObject boom;
	public GameObject box;
	public GameObject proj;
	private Vector2 targetPos;
	private float tfire;
	private Vector2 startPos;
	public float oscilate;
	private int bocs;
    // Start is called before the first frame update
    void Start()
    {
        maxhp=11;
        speed=3;
        atacc=2;
		base.Start();
		tfire= atacc/2;
        //body.velocity = new UnityEngine.Vector2(-1,0);
        oscilate=Random.Range(-3, 3); 
    }

    // Update is called once per frame
    void Update()
    {
        base.isded();
		if (Time.timeScale>0)
		{

			startPos= new Vector2(transform.position.x-2, transform.position.y);
		if (tfire <= 0)
                {
                    Instantiate(proj, startPos, Quaternion.identity);
                    tfire = atacc;
                }
                else
                    tfire -= Time.deltaTime;
        transform.Translate(Vector2.left * speed * Time.deltaTime);  
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
		if(transform.position.x<-16 )
			Destroy(gameObject);

        //SLIDE
       	if (oscilate==0 || transform.position.y+oscilate > 5 || transform.position.y+oscilate<-3.5f)
                oscilate=Random.Range(-1, 2);
            else
                if (transform.position.x<8)
                do
                {
                    targetPos= new Vector2(transform.position.x, transform.position.y+(2*oscilate*Time.deltaTime));
                    transform.position=targetPos;
                }while(transform.position.y==oscilate);
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
